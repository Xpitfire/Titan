using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class FullyConnectedLayerVertex : LayerVertex
    {
        public int NumberOfNeurons { get; internal set; }

        internal FullyConnectedLayerVertex() : this(null) { }
        internal FullyConnectedLayerVertex(string name) : base(VertexKind.FullyConnected, name) { }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            return this;
        }
    }
}
