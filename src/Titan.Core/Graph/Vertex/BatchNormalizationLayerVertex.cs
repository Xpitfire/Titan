using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class BatchNormalizationLayerVertex : LayerVertex
    {
        public bool UseGlobalStats { get; internal set; }

        internal BatchNormalizationLayerVertex() : this(null)  { }
        internal BatchNormalizationLayerVertex(string name) : base(VertexKind.BatchNormalization, name) { }
    }
}
