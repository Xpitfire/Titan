using System;
using System.Linq.Expressions;

namespace Titan.Core.Syntax
{
    [Serializable]
    public class NetworkSyntax : SyntaxNode
    {
        public static event VisitorDelegate<NetworkSyntax> VisitedEvent;

        public NetworkParameterSyntax Parameter { get; internal set; }
        public InputLayerSyntax TrainLayer { get; internal set; }
        public InputLayerSyntax ValidationLayer { get; internal set; }
        public InputLayerSyntax TestLayer { get; internal set; }

        private NetworkSyntax() : this(null) { } // required due to serialization
        internal NetworkSyntax(string name = null) : this (null, name) { }
        internal NetworkSyntax(NetworkParameterSyntax parameter, string name = null) : this(parameter, null, name: name) { }
        internal NetworkSyntax(
            NetworkParameterSyntax parameter,
            InputLayerSyntax trainLayer,
            InputLayerSyntax validationLayer = null,
            InputLayerSyntax testLayer = null,
            string name = null)
        {
            Parameter = parameter;
            Name = name;
            TrainLayer = trainLayer;
            ValidationLayer = validationLayer;
            TestLayer = testLayer;
        }

        public SyntaxNode Root() => this;

        public NetworkSyntax AddLayers(
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

        internal override void Traverse() => VisitedEvent?.Invoke(this);
    }

    [Serializable]
    public sealed class NetworkParameterSyntax : SyntaxNode
    {
        public static event VisitorDelegate<NetworkParameterSyntax> VisitedEvent;

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

        internal override void Traverse() => VisitedEvent?.Invoke(this);
    }
}
