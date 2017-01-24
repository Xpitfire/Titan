using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ConvolutionalLayerSyntax : LayerSyntax
    {
        public static event VisitorDelegate<ConvolutionalLayerSyntax> VisitedEvent;

        private ConvolutionalLayerSyntax() : this(null) { }
        internal ConvolutionalLayerSyntax(string name = null) : base(SyntaxKind.Convolutional, name)
        {
        }

        internal override void Traverse() => VisitedEvent?.Invoke(this);
        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<ConvolutionalLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }
}
