using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ConvolutionalLayerSyntax : LayerSyntax
    {
        private ConvolutionalLayerSyntax() : this(null) { }
        internal ConvolutionalLayerSyntax(string name) : base(SyntaxKind.Convolutional, name)
        {
        }
    }

    [Serializable]
    public sealed class ConvolutionalParameterSyntax : SyntaxNode
    {
        public int KernelSize { get; internal set; }
        public int Stride { get; internal set; }
        internal ConvolutionalParameterSyntax()  { }
    }

}
