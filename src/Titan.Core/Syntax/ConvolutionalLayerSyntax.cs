using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ConvolutionalLayerSyntax : LayerSyntax
    {
        private ConvolutionalLayerSyntax() : this(null) { }
        internal ConvolutionalLayerSyntax(string name = null) : base(SyntaxKind.Convolutional, name)
        {
        }
        
        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<ConvolutionalLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }
}
