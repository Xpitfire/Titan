using System;
using System.Linq;
using Titan.Core.Helper;

namespace Titan.Core.Syntax
{
    [Serializable]
    public class NetworkSyntax : SyntaxNode
    {
        public NetworkParameterSyntax Parameter { get; internal set; }
        public InputLayerSyntax TrainLayer { get; internal set; }
        public InputLayerSyntax ValidationLayer { get; internal set; }
        public InputLayerSyntax TestLayer { get; internal set; }
        public ImmutableList<LayerSyntax> Layers { get; internal set; }

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
            TrainLayer = trainLayer;
            ValidationLayer = validationLayer;
            TestLayer = testLayer;
        }

        public SyntaxNode Root() => this;

        public NetworkSyntax AddInputLayers(
            InputLayerSyntax trainLayer, 
            InputLayerSyntax validationLayer = null, 
            InputLayerSyntax testLayer = null)
        {
            var network = this.Clone<NetworkSyntax>();
            network.TrainLayer = trainLayer;
            network.ValidationLayer = validationLayer;
            network.TestLayer = testLayer;
            return network;
        }

        public NetworkSyntax AddLayer(LayerSyntax layer)
        {
            var network = this.Clone<NetworkSyntax>();

            if (Layers != null)
            {
                if (Layers.Count > 0)
                {
                    layer.PreviousLayer = Layers.Last();
                }
            }
            network.Layers = new ImmutableList<LayerSyntax>(Layers, layer);
            return network;
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
