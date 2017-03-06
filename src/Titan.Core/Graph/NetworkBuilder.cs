using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    public static class NetworkBuilder
    {
        public static Network BuildResNet50()
        {
            var resNet50 = new Network("ResNet-50")
                
                .AddVertex(new InputLayerVertex("data"))
                
                .AddConvLayerOut64Kernel7Pad3Stride2BiasReLUBatchNormScale("conv1")

                .AddVertex(new PoolingLayerVertex("pool1", new PoolingParameter(
                    PoolingLayerKind.Max,
                    kernelSize: 3,
                    stride: 2)))
                
                .AddConvLayerOut256Kernel1Pad0Stride1BatchNormScale("res2a_branch1")
                .AddConvLayerOut64Kernel1Pad0Stride1ReLUBatchNormScale("res2a_branch2a")
                .AddConvLayerOut64Kernel3Pad1Stride1ReLUBatchNormScale("res2a_branch2b")
                .AddConvLayerOut256Kernel1Pad0Stride1BatchNormScale("res2a_branch2c")
                
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
