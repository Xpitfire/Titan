using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ConvolutionalLayerVertex : LayerVertex
    {
        public ConvolutionalLayerParameter Parameter { get; internal set; }

        internal ConvolutionalLayerVertex() : this(null) { }
        internal ConvolutionalLayerVertex(string name) : base(VertexKind.Convolutional, name) { }
        internal ConvolutionalLayerVertex(string name, ConvolutionalLayerParameter parameter) : this(name)
        {
            Parameter = parameter;
        }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(Parameter.NumberOfOutput)] = Parameter.NumberOfOutput;
            props[nameof(Parameter.KernelSize)] = Parameter.KernelSize;
            props[nameof(Parameter.Padding)] = Parameter.Padding;
            props[nameof(Parameter.Stride)] = Parameter.Stride;
            props[nameof(Parameter.BiasTerm)] = Parameter.BiasTerm;
            return props;
        }
    }

    [Serializable]
    public sealed class ConvolutionalLayerParameter
    {
        public int NumberOfOutput { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Padding { get; internal set; }
        public int Stride { get; internal set; }
        public bool BiasTerm { get; internal set; }

        internal ConvolutionalLayerParameter() { }
        internal ConvolutionalLayerParameter(
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
