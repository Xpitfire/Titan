using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    public static class NetworkBuilder
    {
        public static Network BuildResNet50()
        {
            var resNet50 = new Network("ResNet-50")
                
                .AddVertex(new InputLayerVertex("data"))

                .AddLayer(new ConvolutionalLayerVertex("conv1", new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 7,
                    padding: 3,
                    stride: 2,
                    biasTerm: true)),
                    new ActivationLayerVertex("conv1_relu"),
                    new BatchNormalizationLayerVertex("bn_conv1"),
                    new ScaleLayerVertex("scale_conv1"))

                .AddVertex(new PoolingLayerVertex("pool1", new PoolingParameter(
                    PoolingLayerKind.Max,
                    kernelSize: 3,
                    stride: 2)))


                .AddLayer(new ConvolutionalLayerVertex("res2a_branch1", new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)),
                    batchNormalizationLayer: new BatchNormalizationLayerVertex("bn2a_branch1"),
                    scaleLayer: new ScaleLayerVertex("scale2a_branch1"))


                .AddLayer(new ConvolutionalLayerVertex("res2a_branch2a", new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)),
                    new ActivationLayerVertex("res2a_branch2a_relu"),
                    new BatchNormalizationLayerVertex("bn2a_branch2a"),
                    new ScaleLayerVertex("scale2a_branch2a"))

                .AddLayer(new ConvolutionalLayerVertex("res2a_branch2b", new ConvolutionalParameter(
                    numberOfOutput: 64,
                    kernelSize: 31,
                    padding: 1,
                    stride: 1)),
                    new ActivationLayerVertex("res2a_branch2b_relu"),
                    new BatchNormalizationLayerVertex("bn2a_branch2b"),
                    new ScaleLayerVertex("scale2a_branch2b"))

                .AddLayer(new ConvolutionalLayerVertex("res2a_branch2c", new ConvolutionalParameter(
                    numberOfOutput: 256,
                    kernelSize: 1,
                    padding: 0,
                    stride: 1)),
                    batchNormalizationLayer: new BatchNormalizationLayerVertex("bn2a_branch2c"),
                    scaleLayer: new ScaleLayerVertex("scale2a_branch2c"))

                .AddLayer(new EltwiseLayerVertex("res2a"), new ActivationLayerVertex("res2a_relu"))

                .AddEdge("data", "conv1")
                .AddEdge("conv1", "pool1")

                .AddEdge("pool1", "res2a_branch1")
                .AddEdge("pool1", "res2a_branch2a")

                .AddEdge("res2a_branch2a", "res2a_branch2b")
                .AddEdge("res2a_branch2b", "res2a_branch2c")
                .AddEdge("res2a_branch1", "res2a")
                .AddEdge("res2a_branch2c", "res2a")
                ;

            return resNet50;
        }
    }
}
