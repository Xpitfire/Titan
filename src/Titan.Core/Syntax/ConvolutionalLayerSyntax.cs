using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ConvolutionalLayerSyntax : LayerSyntax
    {
        public static event VisitorDelegate<ConvolutionalLayerSyntax> VisitedEvent;

        internal ConvolutionalLayerSyntax() : base(SyntaxKind.Convolutional)
        {
        }

        internal override void Traverse() => VisitedEvent?.Invoke(this);
    }
}
