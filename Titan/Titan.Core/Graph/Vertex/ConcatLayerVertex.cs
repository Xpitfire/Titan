using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ConcatLayerVertex : LayerVertex, IAuxiliaryLayer
    {
        internal ConcatLayerVertex() : this(null) { }
        internal ConcatLayerVertex(string name) : base(VertexKind.Concat, name) { }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            return this;
        }
    }
}
