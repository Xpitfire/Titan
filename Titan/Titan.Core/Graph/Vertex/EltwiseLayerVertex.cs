using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class EltwiseLayerVertex : LayerVertex, IAuxiliaryLayer
    {
        public EltwiseOperationKind OperationKind { get; internal set; }

        internal EltwiseLayerVertex() : this(null) { }
        internal EltwiseLayerVertex(string name) : base(VertexKind.Eltwise, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(OperationKind)] = OperationKind.ToString();
            return props;
        }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            Enum.TryParse(properties[nameof(OperationKind)].ToString(), out EltwiseOperationKind operationKind);
            OperationKind = operationKind;
            return this;
        }
    }

    [Serializable]
    public enum EltwiseOperationKind
    {
        Multiply,
        Add
    }
}
