using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        public static event VisitorDelegate<PoolingLayerSyntax> VisitedEvent;

        internal PoolingLayerSyntax() : base(SyntaxKind.Pooling)
        {
        }

        internal override void Traverse() => VisitedEvent?.Invoke(this);
        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<PoolingLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }
}
