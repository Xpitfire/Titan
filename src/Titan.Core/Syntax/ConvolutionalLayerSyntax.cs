using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ConvolutionalLayerSyntax : LayerSyntax
    {
        internal ConvolutionalLayerSyntax() : base(SyntaxKind.Convolutional)
        {
        }
    }
}
