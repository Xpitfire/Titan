using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class FullyConnectedLayerVertex : LayerVertex, IOperationalLayer
    {
        public int NumberOfNeurons { get; internal set; }

        internal FullyConnectedLayerVertex() : this(null) { }
        internal FullyConnectedLayerVertex(string name) : base(VertexKind.FullyConnected, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(NumberOfNeurons)] = NumberOfNeurons.ToString();
            return props;
        }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            int.TryParse(properties[nameof(NumberOfNeurons)].ToString(), out int numberOfNeurons);
            NumberOfNeurons = numberOfNeurons;
            return this;
        }
    }
}
