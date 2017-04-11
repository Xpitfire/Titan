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

        internal DropoutLayerVertex() : this(null) { }
        internal DropoutLayerVertex(string name) : base(VertexKind.Dropout, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(Rate)] = Rate;
            return props;
        }
    }
}
