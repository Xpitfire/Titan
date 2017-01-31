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
            var list = new List<InputLayerSyntax>
            {
                trainLayer,
                validationLayer,
                testLayer
            };
            network.InputLayers = list.ToImmutableList();
            return network;
        }

        public NetworkSyntax AddOutputLayers(
            params OutputLayerSyntax[] outputLayers)
        {
            var network = this.Clone<NetworkSyntax>();
            if (outputLayers != null && network.Layers != null)
            {
                var lastLayer = new List<LayerSyntax>
                {
                    network.Layers.Last()
                }.ToImmutableList();
                foreach (var outputLayer in outputLayers)
                {
                    outputLayer.ParentLayers = lastLayer;
                }
                network.OutputLayers = outputLayers.ToImmutableList();
            }
            return network;
        }

        public NetworkSyntax AddLayer(LayerSyntax layer)
        {
            var network = this.Clone<NetworkSyntax>();
            var list = new List<LayerSyntax>();
            if (network.Layers == null)
            {
                layer.ParentLayers =
                    new List<LayerSyntax>(network.InputLayers).ToImmutableList();
            }
            else
            {
                foreach (var l in network.Layers)
                {
                    list.Add(l.Clone<LayerSyntax>());
                }
                layer.ParentLayers = new List<LayerSyntax>
                {
                    network.Layers.Last()
                }.ToImmutableList();
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
            if (InputLayers != null)
            {
                foreach (var l in InputLayers)
                {
                    layer = l.FindChildLayerByName(name);
                    if (layer != null) return layer;
                }
            }
            if (OutputLayers != null)
            {
                foreach (var l in Layers)
                {
                    layer = l.FindChildLayerByName(name);
                    if (layer != null) return layer;
                }
            }
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
