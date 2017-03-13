using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ConvolutionalLayerVertex : LayerVertex
    {
        public ConvolutionalParameter Parameter { get; internal set; }

        internal ConvolutionalLayerVertex() : this(null) { }
        internal ConvolutionalLayerVertex(string name) : base(VertexKind.Convolutional, name) { }
        internal ConvolutionalLayerVertex(string name, ConvolutionalParameter parameter) : this(name)
        {
            Parameter = parameter;
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

        internal ConvolutionalParameter() { }
        internal ConvolutionalParameter(
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
