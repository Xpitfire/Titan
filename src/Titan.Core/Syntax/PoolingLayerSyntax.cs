using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        public PoolingLayerType Type { get; internal set; }

        internal PoolingLayerSyntax() : this(PoolingLayerType.Max) { }
        internal PoolingLayerSyntax(PoolingLayerType type) : base(SyntaxKind.Pooling)
        {
            Type = type;
        }
    }

    public enum PoolingLayerType
    {
        Max,
        Average
    }
}
