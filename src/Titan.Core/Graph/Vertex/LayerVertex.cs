using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public abstract class LayerVertex : VertexBase
    {
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
            FullyConnected,
            Softmax
        }
        
        public VertexKind Kind { get; internal set; }
        
        protected LayerVertex(VertexKind kind, string name) : base(name)
        {
            Kind = kind;
        }
    }
}
