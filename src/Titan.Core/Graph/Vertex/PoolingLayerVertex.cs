using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class PoolingLayerVertex : LayerVertex
    {
        public PoolingParameter Parameter { get; internal set; }
        
        private PoolingLayerVertex() : this(null) { }
        public PoolingLayerVertex(string name, PoolingParameter parameter = null) : base(VertexKind.Pooling, name)
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

        private PoolingParameter() { }
        public PoolingParameter(PoolingLayerKind poolingKind,
            int kernelSize,
            int stride)
        {
            PoolingKind = poolingKind;
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
