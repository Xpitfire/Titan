using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ConvolutionalLayerSyntax : LayerSyntax
    {
        public ConvolutionalParameterSyntax Parameter { get; internal set; }

        private ConvolutionalLayerSyntax() : this(null) { }
        internal ConvolutionalLayerSyntax(string name, ConvolutionalParameterSyntax parameter = null) : base(SyntaxKind.Convolutional, name)
        {
            Parameter = parameter;
        }

        public ConvolutionalLayerSyntax AddParameter(ConvolutionalParameterSyntax parameter)
        {
            var clone = this.DeepClone();
            clone.Parameter = parameter;
            return clone;
        }
    }

    [Serializable]
    public sealed class ConvolutionalParameterSyntax : SyntaxNode
    {
        public int NumberOfOutput { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Padding { get; internal set; }
        public int Stride { get; internal set; }
        public ActivationFunctionType ActivationFunction { get; internal set; }

        private ConvolutionalParameterSyntax() { }
        internal ConvolutionalParameterSyntax(ActivationFunctionType activationFunction, 
            int numberOfOutput, 
            int kernelSize, 
            int padding, 
            int stride)
        {
            ActivationFunction = activationFunction;
            NumberOfOutput = numberOfOutput;
            KernelSize = kernelSize;
            Padding = padding;
            Stride = stride;
        }
    }

    public enum ActivationFunctionType
    {
        ReLU,
        Sigmoid,
        TanH
    }

}
