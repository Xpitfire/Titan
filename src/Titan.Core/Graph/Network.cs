using System;
using System.Linq;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    [Serializable]
    public class Network
    {
        public GraphBuilderBase Graph { get; internal set; }
        public NetworkParameter Parameter { get; internal set; }
        public string Name { get; internal set; }

        internal Network() { }
    }

    [Serializable]
    public sealed class NetworkParameter
    {
        public static readonly NetworkParameter DefaultNetworkParameter = new NetworkParameter
        {
            BatchSize = DefaultBatchSize,
            Epochs = DefaultEpochSize,
            Seed = DefaultSeedValue,
            Updater = DefaultUpdaterType,
            LearningRate = DefaultLearningRate
        };

        public const int DefaultEpochSize = 100;
        public const UpdaterType DefaultUpdaterType = UpdaterType.StochasticGradientDescent;
        public const float DefaultLearningRate = 0.003f;
        public const int DefaultBatchSize = 50;
        public const int DefaultSeedValue = 0; // random seed

        public int Epochs { get; internal set; }
        public int BatchSize { get; internal set; }
        public int Seed { get; internal set; }
        public UpdaterType Updater { get; internal set; }
        public float LearningRate { get; internal set; }

        internal NetworkParameter() { }        
    }

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
}
