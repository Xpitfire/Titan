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
        public ImmutableList<SyntaxNode> Layers { get; internal set; }

        private NetworkSyntax() : base() { } // required due to serialization
        internal NetworkSyntax(string name) : this(name, null) { }
        internal NetworkSyntax(
            string name,
            NetworkParameterSyntax parameter = null,
            ImmutableList<SyntaxNode> layers = null) : base(name)
        {
            Parameter = parameter;
            Layers = layers;
        }
        
        public NetworkSyntax AddLayer(SyntaxNode layer)
        {
            var network = this.DeepClone();
            var layers = network.Layers != null ? network.Layers.ToList() : new List<SyntaxNode>();
            layers.Add(layer);
            network.Layers = layers.ToImmutableList();
            return network;
        }

        public LayerSyntax FindLayerByIdentifier(Identifier id)
            => (id == null) ? null : FindLayerByName(id.Id);
        public LayerSyntax FindLayerByName(string name)
        {
            if (name == null) return null;
            // TODO implement working search
            return null;
        }

        public override void Traverse()
        {
            base.Traverse();
            Parameter?.Traverse();
            foreach (var layer in Layers)
            {
                layer.Traverse();
            }
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
