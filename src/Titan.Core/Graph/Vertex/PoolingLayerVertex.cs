using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class PoolingLayerVertex : LayerVertex
    {
        public PoolingParameter Parameter { get; internal set; }

        internal PoolingLayerVertex() : this(null) { }
        internal PoolingLayerVertex(string name) : base(VertexKind.Pooling, name) { }

        public PoolingLayerVertex(string name, PoolingParameter parameter) : this(name)
        {
            Parameter = parameter;
        }
    }

    [Serializable]
    public sealed class PoolingParameter
    {
        public PoolingLayerKind PoolingKind { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Stride { get; internal set; }

        internal PoolingParameter() { }
        internal PoolingParameter(PoolingLayerKind kind, int kernelSize, int stride)
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
