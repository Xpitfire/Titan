using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        public PoolingLayerKind PoolingKind { get; internal set; }

        internal PoolingLayerSyntax(string name, string input) : this(PoolingLayerKind.Max, name, input) { }
        internal PoolingLayerSyntax(PoolingLayerKind kind, string name, string input) : base(SyntaxKind.Pooling, name, input)
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
