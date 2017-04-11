using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    public static class Prefab
    {
        public static Network BuildNetwork()
        {
            var builder = new NetworkBuilder("LeNet")
                .AddInputLayer(new InputLayerVertex("data"))
                .AddLayerBlock(
                    b => b.AddLayer(new ConvolutionalLayerVertex("conv1", new ConvolutionalLayerParameter(
                            numberOfOutput: 64,
                            kernelSize: 7,
                            padding: 3,
                            stride: 2,
                            biasTerm: true)))
                          .AddActivation(new ActivationLayerVertex("conv1_relu"))
                          .AddBatchNorm(new BatchNormalizationLayerVertex("bn_conv1"))
                          .AddScale(new ScaleLayerVertex("scale_conv1")))

                .AddLayer(new PoolingLayerVertex("pool1", new PoolingLayerParameter(
                    PoolingLayerKind.Max,
                    kernelSize: 3,
                    stride: 2)))

                .AddResidualBlock(
                    left: b => b.AddLayerBlock(
                        lb => lb.AddLayer(new ConvolutionalLayerVertex("res2a_branch1", new ConvolutionalLayerParameter(
                            numberOfOutput: 256,
                            kernelSize: 1,
                            padding: 0,
                            stride: 1,
                            biasTerm: false)))
                          .AddBatchNorm(new BatchNormalizationLayerVertex("bn2a_branch1"))
                          .AddScale(new ScaleLayerVertex("scale2a_branch1"))),
                    right: b => b.AddLayerBlock(
                        lb => lb.AddLayer(new ConvolutionalLayerVertex("res2a_branch2a", new ConvolutionalLayerParameter(
                            numberOfOutput: 64,
                            kernelSize: 1,
                            padding: 0,
                            stride: 1,
                            biasTerm: false)))
                              .AddBatchNorm(new BatchNormalizationLayerVertex("bn2a_branch2a"))
                              .AddScale(new ScaleLayerVertex("scale2a_branch2a"))
                              .AddActivation(new ActivationLayerVertex("res2a_branch2a_relu")))
                            .AddLayerBlock(
                        lb => lb.AddLayer(new ConvolutionalLayerVertex("res2a_branch2b", new ConvolutionalLayerParameter(
                                numberOfOutput: 64,
                                kernelSize: 3,
                                padding: 1,
                                stride: 1,
                                biasTerm: false)))
                              .AddBatchNorm(new BatchNormalizationLayerVertex("bn2a_branch2b"))
                              .AddScale(new ScaleLayerVertex("scale2a_branch2b"))
                              .AddActivation(new ActivationLayerVertex("res2a_branch2b_relu")))
                            .AddLayerBlock(
                        lb => lb.AddLayer(new ConvolutionalLayerVertex("res2a_branch2c", new ConvolutionalLayerParameter(
                                numberOfOutput: 256,
                                kernelSize: 1,
                                padding: 0,
                                stride: 1,
                                biasTerm: false)))
                              .AddBatchNorm(new BatchNormalizationLayerVertex("bn2a_branch2c"))
                              .AddScale(new ScaleLayerVertex("scale2a_branch2c"))))
                .AddEltwise(new EltwiseLayerVertex("res2a"))
                .AddActivation(new ActivationLayerVertex("res2a_relu"));

            return builder.BuildNetwork();
        }
        
    }
}
