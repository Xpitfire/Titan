using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ScaleLayerVertex : LayerVertex
    {
        public bool BiasTerm { get; internal set; }

        internal ScaleLayerVertex() : this(null) { }
        internal ScaleLayerVertex(string name) : base(VertexKind.Scaling, name) { }
    }
}
