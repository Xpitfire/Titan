using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class DropoutLayerVertex : LayerVertex
    {
        public double Rate { get; internal set; }

        private DropoutLayerVertex() : this(null, 0.0) { }
        public DropoutLayerVertex(string name, double rate) : base(VertexKind.Dropout, name)
        {
            Rate = rate;
        }
    }
}
