using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        internal PoolingLayerSyntax() : base(SyntaxKind.Pooling)
        {
        }

        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<PoolingLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }
}
