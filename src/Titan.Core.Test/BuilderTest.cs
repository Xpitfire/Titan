using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Vertex;
using static Titan.Core.Graph.Vertex.VertexFactory;

namespace Titan.Core.Test
{
    [TestClass]
    public class BuilderTest
    {
        //[TestMethod]
        //public void TestAddInputLayer()
        //{
        //    var inputLayer = InputLayer("data1");
        //    var builder = new NetworkBuilder("test1")
        //        .AddInputLayer(inputLayer);
        //    var graph = builder.BuildGraph();
        //    Assert.IsTrue(graph.ContainsVertex(inputLayer));
        //    Assert.IsTrue(graph.Vertices.First(v => Equals(v.Identifier, inputLayer.Identifier)) != null);
        //}

        //[TestMethod]
        //public void TestAddSingleLayer()
        //{
        //    var inputLayer = InputLayer("data2");
        //    var conv = ConvLayer("conv2", ConvLayerParam(7, 64));
        //    var builder = new NetworkBuilder("test2")
        //        .AddInputLayer(inputLayer)
        //        .AddLayer(conv);
        //    var graph = builder.BuildGraph();
        //    Assert.IsTrue(graph.ContainsVertex(inputLayer));
        //    Assert.IsTrue(graph.ContainsVertex(conv));
        //    Assert.IsTrue(graph.ContainsEdge(inputLayer, conv));
        //}

        //[TestMethod]
        //public void TestAddMultipleLayers()
        //{
        //    var inputLayer = InputLayer("data3");
        //    var conv = ConvLayer("conv3", ConvLayerParam(7, 64));
        //    var pool = PoolLayer("pool3", PoolLayerParam(7));
        //    var conv2 = ConvLayer("conv3-2", ConvLayerParam(5, 64));
        //    var builder = new NetworkBuilder("test3")
        //        .AddInputLayer(inputLayer)
        //        .AddLayer(conv)
        //        .AddLayer(pool)
        //        .AddLayer(conv2);

        //    var graph = builder.BuildGraph();
        //    Assert.IsTrue(graph.ContainsVertex(inputLayer));
        //    Assert.IsTrue(graph.ContainsVertex(conv));
        //    Assert.IsTrue(graph.ContainsVertex(conv2));
        //    Assert.IsTrue(graph.ContainsVertex(pool));

        //    Assert.IsTrue(graph.ContainsEdge(inputLayer, conv));
        //    Assert.IsTrue(graph.ContainsEdge(conv, pool));
        //    Assert.IsTrue(graph.ContainsEdge(pool, conv2));

        //    Assert.IsFalse(graph.ContainsEdge(inputLayer, conv2));
        //    Assert.IsFalse(graph.ContainsEdge(inputLayer, pool));

        //}

        //[TestMethod]
        //public void TestAddBlockLayer()
        //{
        //    var inputLayer = InputLayer("data4");
        //    var conv = ConvLayer("conv4", ConvLayerParam(7, 64));
        //    var batchNorm = BatchNormLayer("bn4");
        //    var scale = ScaleLayer("scale4");
        //    var activ = ActivationLayer("relu4");
        //    var conv2 = ConvLayer("conv4-2", ConvLayerParam(7, 64));
        //    var pool = PoolLayer("pool4", PoolLayerParam(5));
        //    var conv3 = ConvLayer("conv4-3", ConvLayerParam(5, 32));
        //    var dropout = DropoutLayer("drop4", 0.6f);

        //    var builder = new NetworkBuilder("test4")
        //        .AddInputLayer(inputLayer)
        //        .AddLayerBlock(b => b
        //            .AddLayer(conv)
        //            .AddBatchNorm(batchNorm)
        //            .AddScale(scale)
        //            .AddActivation(activ))
        //        .AddLayer(pool)
        //        .AddLayer(conv2)
        //        .AddLayerBlock(b => b
        //            .AddLayer(conv3)
        //            .AddDropout(dropout));
        //    var graph = builder.BuildGraph();

        //    Assert.IsTrue(graph.ContainsEdge(inputLayer, conv));

        //    Assert.IsTrue(graph.ContainsEdge(conv, batchNorm));
        //    Assert.IsTrue(graph.ContainsEdge(conv, scale));
        //    Assert.IsTrue(graph.ContainsEdge(conv, activ));

        //    Assert.IsTrue(graph.ContainsEdge(conv, pool));
        //    Assert.IsTrue(graph.ContainsEdge(pool, conv2));
        //    Assert.IsTrue(graph.ContainsEdge(conv2, conv3));

        //    Assert.IsTrue(graph.ContainsEdge(conv3, dropout));

        //    Assert.IsFalse(graph.ContainsEdge(inputLayer, batchNorm));
        //    Assert.IsFalse(graph.ContainsEdge(inputLayer, scale));
        //    Assert.IsFalse(graph.ContainsEdge(inputLayer, activ));
        //    Assert.IsFalse(graph.ContainsEdge(inputLayer, pool));

        //    Assert.IsFalse(graph.ContainsEdge(pool, conv3));
        //    Assert.IsFalse(graph.ContainsEdge(pool, dropout));

        //    Assert.IsFalse(graph.ContainsEdge(conv2, dropout));

        //}

        [TestMethod]
        public void TestAddResidualBlock()
        {
            var inputLayer = InputLayer("data5");
            var conv = ConvLayer("conv5", ConvLayerParam(7, 64));
            var batchNorm = BatchNormLayer("bn5");
            var scale = ScaleLayer("scale5");
            var conv2 = ConvLayer("conv5-2", ConvLayerParam(7, 64));
            var batchNorm2 = BatchNormLayer("bn5-2");
            var scale2 = ScaleLayer("scale5-2");
            var conv3 = ConvLayer("conv5-3", ConvLayerParam(7, 64));
            var batchNorm3 = BatchNormLayer("bn5-3");
            var scale3 = ScaleLayer("scale5-3");
            var eltwise = EltwiseLayer("res5");
            var pool = PoolLayer("pool5", PoolLayerParam(5));
            var softmax = SoftmaxLayer("softmax5", 5);

            var builder = new NetworkBuilder("test5")
                .AddInputLayer(inputLayer)
                .AddResidualBlock(
                    left: b => b
                        .AddLayerBlock(lb => lb
                            .AddLayer(conv)
                            .AddBatchNorm(batchNorm)
                            .AddScale(scale)),
                    right: b => b
                        .AddLayerBlock(lb => lb
                            .AddLayer(conv2)
                            .AddBatchNorm(batchNorm2)
                            .AddScale(scale2))
                        .AddLayerBlock(lb => lb
                            .AddLayer(conv3)
                            .AddBatchNorm(batchNorm3)
                            .AddScale(scale3)))
                .AddEltwise(eltwise)
                .AddLayer(pool)
                .AddLayer(softmax);

            builder.PersistGraph();

            //Assert.IsTrue(graph.ContainsEdge(inputLayer, conv));
            //Assert.IsTrue(graph.ContainsEdge(inputLayer, conv2));
            //Assert.IsFalse(graph.ContainsEdge(inputLayer, conv3));

            //Assert.IsFalse(graph.ContainsEdge(conv, conv2));

            //Assert.IsTrue(graph.ContainsEdge(conv, batchNorm));
            //Assert.IsTrue(graph.ContainsEdge(conv, scale));
            //Assert.IsFalse(graph.ContainsEdge(inputLayer, batchNorm));
            //Assert.IsFalse(graph.ContainsEdge(inputLayer, scale));

            //Assert.IsTrue(graph.ContainsEdge(conv2, batchNorm2));
            //Assert.IsTrue(graph.ContainsEdge(conv2, scale2));

            //Assert.IsTrue(graph.ContainsEdge(conv2, conv3));
            //Assert.IsTrue(graph.ContainsEdge(conv3, batchNorm3));
            //Assert.IsTrue(graph.ContainsEdge(conv3, scale3));

            //Assert.IsFalse(graph.ContainsEdge(conv3, conv));
            //Assert.IsTrue(graph.ContainsEdge(conv3, eltwise));
            //Assert.IsTrue(graph.ContainsEdge(conv, eltwise));

            //Assert.IsTrue(graph.ContainsEdge(eltwise, pool));

        }

    }
}
