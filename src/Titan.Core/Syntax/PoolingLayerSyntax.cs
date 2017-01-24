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
    }
}
