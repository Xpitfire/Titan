using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        public PoolingLayerKind PoolingKind { get; internal set; }

        internal PoolingLayerSyntax() : this(PoolingLayerKind.Max) { }
        internal PoolingLayerSyntax(PoolingLayerKind kind) : base(SyntaxKind.Pooling)
        {
            PoolingKind = kind;
        }
    }

    public enum PoolingLayerKind
    {
        Max,
        Average
    }
}
