using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class BatchNormalizationLayerVertex : LayerVertex
    {
        public bool UseGlobalStats { get; internal set; }

        private BatchNormalizationLayerVertex() : this(null)  { }
        public BatchNormalizationLayerVertex(string name, bool useGlobalStats = true) : base(VertexKind.BatchNormalization, name)
        {
            UseGlobalStats = useGlobalStats;
        }
    }
}
