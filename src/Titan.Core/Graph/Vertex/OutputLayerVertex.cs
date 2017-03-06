using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class OutputLayerVertex : LayerVertex
    {
        public int NumberOfClasses { get; internal set; }

        private OutputLayerVertex() : this(null, 0) { }

        public OutputLayerVertex(string name, int numberOfClasses) : base(VertexKind.Softmax, name)
        {
            NumberOfClasses = numberOfClasses;
        }
    }
}
