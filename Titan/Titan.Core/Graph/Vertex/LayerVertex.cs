using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public abstract class LayerVertex : VertexBase
    {
        public VertexKind Kind { get; internal set; }
        
        protected LayerVertex(VertexKind kind, string name) : base(name)
        {
            Kind = kind;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            return new Dictionary<string, object>
            {
                { nameof(Name), Name },
                { nameof(Kind), Kind.ToString() }
            };
        }

        internal virtual LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            Name = properties[nameof(Name)].ToString();
            return this;
        }
    }

    [Serializable]
    public enum VertexKind
    {
        Input,
        Convolutional,
        Pooling,
        Scaling,
        Dropout,
        BatchNormalization,
        Activation,
        Eltwise,
        Concat,
        FullyConnected,
        Softmax
    }

}
