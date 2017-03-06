using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using QuickGraph;
using Titan.Core.Collection;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Edge
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class LayerBuilder
    {

        public static LayerVertex Convolution1X1()
        {
            return new ConvolutionalLayerVertex("conv1x1");
        }

        public static Network ResNet50()
        {
            var resNet50 = new Network("ResNet-50")

                .AddVertex(new InputLayerVertex("data"))

                .AddVertex(new ConvolutionalLayerVertex("conv1", new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 7,
                    padding: 3,
                    stride: 2,
                    biasTerm: true)))
                .AddVertex(new BatchNormalizationLayerVertex("bn_conv1"))
                .AddVertex(new ScaleLayerVertex("scale_conv1"))
                .AddVertex(new ActivationLayerVertex("conv1_relu"))

                .AddVertex(new PoolingLayerVertex("pool1", new PoolingParameter(
                    PoolingLayerKind.Max,
                    kernelSize: 3,
                    stride: 2)))


                .AddVertex(new ConvolutionalLayerVertex("res2a_branch1", new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)))
                .AddVertex(new BatchNormalizationLayerVertex("bn2a_branch1"))
                .AddVertex(new ScaleLayerVertex("scale2a_branch1"))


                .AddVertex(new ConvolutionalLayerVertex("res2a_branch2a", new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)))
                .AddVertex(new BatchNormalizationLayerVertex("bn2a_branch2a"))
                .AddVertex(new ScaleLayerVertex("scale2a_branch2a"))
                .AddVertex(new ActivationLayerVertex("res2a_branch2a_relu"))

                .AddVertex(new ConvolutionalLayerVertex("res2a_branch2b", new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)))
                .AddVertex(new BatchNormalizationLayerVertex("bn2a_branch2b"))
                .AddVertex(new ScaleLayerVertex("scale2a_branch2b"))
                .AddVertex(new ActivationLayerVertex("res2a_branch2b_relu"))

                .AddVertex(new ConvolutionalLayerVertex("res2a_branch2c", new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)))
                .AddVertex(new BatchNormalizationLayerVertex("bn2a_branch2c"))
                .AddVertex(new ScaleLayerVertex("scale2a_branch2c"))

                .AddVertex(new EltwiseLayerVertex("res2a"))
                .AddVertex(new ActivationLayerVertex("res2a_relu"))

                .AddEdge("data", "conv1")

                .AddEdge("conv1", "bn_conv1", cycle: true)
                .AddEdge("conv1", "scale_conv1", cycle: true)
                .AddEdge("conv1", "conv1_relu", cycle: true)

                .AddEdge("conv1", "pool1")

                .AddEdge("pool1", "res2a_branch1")
                .AddEdge("res2a_branch1", "bn2a_branch1", cycle: true)
                .AddEdge("res2a_branch1", "scale2a_branch1", cycle: true)

                .AddEdge("pool1", "res2a_branch2a")
                .AddEdge("res2a_branch2a", "bn2a_branch2a", cycle: true)
                .AddEdge("res2a_branch2a", "scale2a_branch2a", cycle: true)
                .AddEdge("res2a_branch2a", "res2a_branch2a_relu", cycle: true)

                .AddEdge("res2a_branch2a", "res2a_branch2b")
                .AddEdge("res2a_branch2b", "bn2a_branch2b", cycle: true)
                .AddEdge("res2a_branch2b", "scale2a_branch2b", cycle: true)
                .AddEdge("res2a_branch2b", "res2a_branch2b_relu", cycle: true)

                .AddEdge("res2a_branch2b", "res2a_branch2c")
                .AddEdge("res2a_branch2c", "bn2a_branch2c", cycle: true)
                .AddEdge("res2a_branch2c", "scale2a_branch2c", cycle: true)

                .AddEdge("res2a_branch1", "res2a")
                .AddEdge("res2a_branch2c", "res2a")
                .AddEdge("res2a", "res2a_relu", cycle: true)
                ;

            return resNet50;
        }
        
    }
}
