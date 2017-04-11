using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class PoolingLayerVertex : LayerVertex
    {
        public PoolingLayerParameter Parameter { get; internal set; }

        internal PoolingLayerVertex() : this(null) { }
        internal PoolingLayerVertex(string name) : base(VertexKind.Pooling, name) { }

        public PoolingLayerVertex(string name, PoolingLayerParameter parameter) : this(name)
        {
            Parameter = parameter;
        }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(Parameter.PoolingKind)] = Parameter.PoolingKind.ToString();
            props[nameof(Parameter.KernelSize)] = Parameter.KernelSize;
            props[nameof(Parameter.Stride)] = Parameter.Stride;
            return props;
        }
    }

    [Serializable]
    public sealed class PoolingLayerParameter
    {
        public PoolingLayerKind PoolingKind { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Stride { get; internal set; }

        internal PoolingLayerParameter() { }
        internal PoolingLayerParameter(PoolingLayerKind kind, int kernelSize, int stride)
        {
            PoolingKind = kind;
            KernelSize = kernelSize;
            Stride = stride;
        }
    }

    public enum PoolingLayerKind
    {
        Max,
        Average
    }
}
