using System.Diagnostics.CodeAnalysis;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class GraphBuilder
    {

        public static Network AddConvLayerOut64Kernel7Pad3Stride2BiasReLUBatchNormScale(
            this Network network, string name)
        {
            return network.AddCycles(new ConvolutionalLayerVertex(name, new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 7,
                    padding: 3,
                    stride: 2,
                    biasTerm: true)),
                    new ActivationLayerVertex($"{name}_relu"),
                    new BatchNormalizationLayerVertex($"bn_{name}"),
                    new ScaleLayerVertex($"scale_{name}"));
        }

        public static Network AddConvLayerOut64Kernel1Pad0Stride1ReLUBatchNormScale(
            this Network network, string name)
        {
            return network.AddCycles(new ConvolutionalLayerVertex(name, new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1,
                    biasTerm: true)),
                    new ActivationLayerVertex($"{name}_relu"),
                    new BatchNormalizationLayerVertex($"bn_{name}"),
                    new ScaleLayerVertex($"scale_{name}"));
        }

        public static Network AddConvLayerOut64Kernel3Pad1Stride1ReLUBatchNormScale(
            this Network network, string name)
        {
            return network.AddCycles(new ConvolutionalLayerVertex(name, new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 3,
                    padding: 1,
                    stride: 1,
                    biasTerm: true)),
                    new ActivationLayerVertex($"{name}_relu"),
                    new BatchNormalizationLayerVertex($"bn_{name}"),
                    new ScaleLayerVertex($"scale_{name}"));
        }

        public static Network AddConvLayerOut256Kernel1Pad0Stride1BatchNormScale(
            this Network network, string name)
        {
            return network.AddCycles(new ConvolutionalLayerVertex(name, new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)),
                    new BatchNormalizationLayerVertex($"bn_{name}"),
                    new ScaleLayerVertex($"scale_{name}"));
        }
        
    }
}
