using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ScaleLayerVertex : LayerVertex
    {
        public bool BiasTerm { get; internal set; }

        private ScaleLayerVertex() : this(null) { }
        public ScaleLayerVertex(string name, bool biasTerm = true) : base(VertexKind.Scaling, name)
        {
            BiasTerm = biasTerm;
        }
    }
}
