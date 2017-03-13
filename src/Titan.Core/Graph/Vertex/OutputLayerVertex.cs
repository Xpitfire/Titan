using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class OutputLayerVertex : LayerVertex
    {
        public int NumberOfClasses { get; internal set; }

        internal OutputLayerVertex() : this(null) { }
        internal OutputLayerVertex(string name) : base(VertexKind.Softmax, name) { }
    }
}
