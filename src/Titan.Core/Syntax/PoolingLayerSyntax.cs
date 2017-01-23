using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        internal PoolingLayerSyntax() : base(SyntaxKind.Pooling)
        {
        }

    }
}
