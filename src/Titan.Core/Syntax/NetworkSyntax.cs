using System;
using System.Collections.Generic;
using System.Linq;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public class NetworkSyntax : SyntaxNode
    {
        public NetworkParameterSyntax Parameter { get; internal set; }
        public ImmutableList<InputLayerSyntax> InputLayers { get; internal set; }
        public LayerSyntax RootLayer { get; internal set; }
        public ImmutableList<LayerSyntax> Layers { get; internal set; }
        public ImmutableList<OutputLayerSyntax> OutputLayers { get; internal set; }

        private NetworkSyntax() : this(null) { } // required due to serialization
        internal NetworkSyntax(string name = null) : this(null, name) { }
        internal NetworkSyntax(NetworkParameterSyntax parameter, string name = null) : this(parameter, null, name: name) { }
        internal NetworkSyntax(
            NetworkParameterSyntax parameter,
            InputLayerSyntax trainLayer,
            InputLayerSyntax validationLayer = null,
            InputLayerSyntax testLayer = null,
            string name = null) : base(name)
        {
            Parameter = parameter;
            var list = new List<InputLayerSyntax>
            {
                trainLayer,
                validationLayer,
                testLayer
            };
            InputLayers = list.ToImmutableList();
        }

        public NetworkSyntax AddInputLayers(
            InputLayerSyntax trainLayer,
            InputLayerSyntax validationLayer = null,
            InputLayerSyntax testLayer = null)
        {
            var network = this.Clone<NetworkSyntax>();
            network.InputLayers = new List<InputLayerSyntax>
            {
                trainLayer,
                validationLayer,
                testLayer
            }.ToImmutableList();
            return network;
        }

        public NetworkSyntax AddOutputLayers(
            params OutputLayerSyntax[] outputLayers)
        {
            var network = this.Clone<NetworkSyntax>();
            if (outputLayers != null)
            {
                network.OutputLayers = outputLayers.ToImmutableList();
            }
            return network;
        }

        public NetworkSyntax AddLayer(LayerSyntax layer)
        {
            var network = this.Clone<NetworkSyntax>();
            var list = new List<LayerSyntax>();
            if (network.RootLayer == null)
            {
                network.RootLayer = layer;
            }
            else
            {
                network.RootLayer = network.RootLayer.Clone<LayerSyntax>();
                LayerSyntax prevLayer = null;
                LayerSyntax curLayer = network.RootLayer;
                // TODO: link layers together via recursion (parent and children)
                foreach (var l in network.Layers)
                {
                    if (prevLayer != null)
                    {
                        curLayer.ParentLayer = prevLayer;
                    }
                    curLayer = l.Clone<LayerSyntax>();
                    list.Add(prevLayer);
                    prevLayer = curLayer;
                }
                layer.ParentLayer = network.Layers.Last();
            }
            list.Add(layer);
            network.Layers = list.ToImmutableList();
            return network;
        }

        public LayerSyntax FindLayerByIdentifier(IdentifierSyntax id)
            => (id == null) ? null : FindLayerByName(id.Id);
        public LayerSyntax FindLayerByName(string name)
        {
            if (name == null) return null;
            LayerSyntax layer = null;
            if (Layers != null)
            {
                foreach (var l in Layers)
                {
                    layer = l.FindChildLayerByName(name);
                    if (layer != null) return layer;
                }
            }
            return null;
        } 
    }

    [Serializable]
    public sealed class NetworkParameterSyntax : SyntaxNode
    {
        public const int DefaultEpochSize = 100;
        public const UpdaterType DefaultUpdaterType = UpdaterType.StochasticGradientDescent;
        public const float DefaultLearningRate = 0.003f;
        public const int DefaultBatchSize = 50;
        public const int DefaultSeedValue = 0; // random seed

        [Serializable]
        public enum UpdaterType
        {
            StochasticGradientDescent,
            Adam,
            AdaDelta,
            Nesterov,
            Adagrad,
            RmsProp
        }

        public int Epochs { get; internal set; }
        public int BatchSize { get; internal set; }
        public int Seed { get; internal set; }
        public UpdaterType Updater { get; internal set; }
        public float LearningRate { get; internal set; }

        private NetworkParameterSyntax() { }
        internal NetworkParameterSyntax(
            int epochs = DefaultEpochSize,
            UpdaterType updater = DefaultUpdaterType,
            float learningRate = DefaultLearningRate,
            int batchSize = DefaultBatchSize,
            int seed = DefaultSeedValue)
        {
            Epochs = epochs;
            BatchSize = batchSize;
            Seed = seed;
            Updater = updater;
            LearningRate = learningRate;
        }

    }
}
