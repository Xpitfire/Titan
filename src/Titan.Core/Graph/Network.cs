using System;
using System.Linq;
using QuickGraph;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    [Serializable]
    public class Network
    {
        public AdjacencyGraph<LayerVertex, Edge<LayerVertex>> Graph { get; }
        public NetworkParameter Parameter { get; }
        public string Name { get; }

        private Network() { }
        public Network(string name) : this(name, null) { }
        public Network(
            string name,
            NetworkParameter parameter = null,
            AdjacencyGraph<LayerVertex, Edge<LayerVertex>> graph = null)
        {
            Name = name;
            Parameter = parameter ?? NetworkParameter.DefaultNetworkParameter;
            Graph = graph ?? new AdjacencyGraph<LayerVertex, Edge<LayerVertex>>(allowParallelEdges: true); ;
        }

        internal Network AddVertex(LayerVertex vertex)
        {
            Graph.AddVertex(vertex);
            return this;
        }
        
        internal Network AddEdge(string vertexId1, string vertexId2, bool cycle = false)
        {
            var vertex1 = Graph.Vertices.First(v => v.Identifier.Id == vertexId1);
            var vertex2 = Graph.Vertices.FirstOrDefault(v => v.Identifier.Id == vertexId2);
            if (vertex1 == null)
                throw new ArgumentException($"Could not find defined vertex ID: {vertexId1}");
            if (vertex2 == null)
                throw new ArgumentException($"Could not find defined vertex ID: {vertexId2}");
            Graph.AddEdge(new Edge<LayerVertex>(vertex1, vertex2));
            if (cycle)
                Graph.AddEdge(new Edge<LayerVertex>(vertex2, vertex1));
            return this;
        }
    }

    [Serializable]
    public sealed class NetworkParameter
    {
        public static readonly NetworkParameter DefaultNetworkParameter = new NetworkParameter();

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

        private NetworkParameter() { }
        public NetworkParameter(
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
