using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        public PoolingLayerKind PoolingKind { get; internal set; }

        internal PoolingLayerSyntax(string name) : this(PoolingLayerKind.Max, name) { }
        internal PoolingLayerSyntax(PoolingLayerKind kind, string name) : base(SyntaxKind.Pooling, name)
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
