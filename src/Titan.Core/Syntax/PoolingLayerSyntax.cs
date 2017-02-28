using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        public PoolingParameterSyntax Parameter { get; internal set; }
        
        private PoolingLayerSyntax() : this(null) { }
        internal PoolingLayerSyntax(string name, PoolingParameterSyntax parameter = null) : base(SyntaxKind.Pooling, name)
        {
            Parameter = parameter;
        }
    }

    [Serializable]
    public sealed class PoolingParameterSyntax : SyntaxNode
    {
        public PoolingLayerKind PoolingKind { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Stride { get; internal set; }

        private PoolingParameterSyntax() { }
        internal PoolingParameterSyntax(PoolingLayerKind poolingKind,
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
