using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        public static event VisitorDelegate<OutputLayerSyntax> VisitedEvent;

        internal OutputLayerSyntax() : base(SyntaxKind.Output)
        {
        }

        internal override void Traverse() => VisitedEvent?.Invoke(this);
    }
}
