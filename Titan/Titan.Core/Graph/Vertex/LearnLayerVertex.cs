using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class LearnLayerVertex : LayerVertex, IAttachableLayer
    {
        public int LocalSize { get; internal set; }
        public float Alpha { get; internal set; }
        public float Beta { get; internal set; }

        internal LearnLayerVertex() : this(null) { }
        internal LearnLayerVertex(string name) : base(VertexKind.Concat, name) { }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            return this;
        }

    }
}
