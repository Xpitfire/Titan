using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ConvolutionalLayerVertex : LayerVertex
    {
        public ConvolutionalParameter Parameter { get; internal set; }

        private ConvolutionalLayerVertex() : this(null) { }
        public ConvolutionalLayerVertex(string name, ConvolutionalParameter parameter = null) : base(VertexKind.Convolutional, name)
        {
            Parameter = parameter;
        }

        public ConvolutionalLayerVertex AddParameter(ConvolutionalParameter parameter)
        {
            var clone = this.DeepClone();
            clone.Parameter = parameter;
            return clone;
        }
    }

    [Serializable]
    public sealed class ConvolutionalParameter
    {
        public int NumberOfOutput { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Padding { get; internal set; }
        public int Stride { get; internal set; }
        public bool BiasTerm { get; internal set; }

        private ConvolutionalParameter() { }
        public ConvolutionalParameter(
            int numberOfOutput, 
            int kernelSize, 
            int padding, 
            int stride,
            bool biasTerm = false)
        {
            NumberOfOutput = numberOfOutput;
            KernelSize = kernelSize;
            Padding = padding;
            Stride = stride;
            BiasTerm = biasTerm;
        }
    }

}
