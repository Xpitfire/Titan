using System;

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
