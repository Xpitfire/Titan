using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Titan.Core.Default;
using Titan.Core.Syntax;
using static Titan.Core.Syntax.SyntaxFactory;

namespace Titan.Core.Test
{
    [TestClass]
    public class SyntaxTest
    {
        public static readonly NetworkSyntax network = 
            Network("Demo")
            .AddInputLayers(
            InputLayer(name: "train"),
            InputLayer(name: "val", type: InputLayerKind.Validation),
            InputLayer(name: "test", type: InputLayerKind.Test))
            .AddLayer(ConvolutionalLayer(name: "conv1", input: "train"))
            .AddLayer(ConvolutionalLayer(name: "conv2", input: "conv1"))
            .AddLayer(ConvolutionalLayer(name: "conv3", input: "conv2"))
            .AddLayer(ConvolutionalLayer(name: "conv4", input: "conv3"))
            .AddOutputLayers(OutputLayer(name: "output", input: "conv4"));
        
        [TestMethod]
        public void TestNodeClone()
        {
            var network = Network("Demo", NetworkParameter())
                .AddInputLayers(InputLayer (name: "train", data: Dimension.Default, label: Label.Empty));
            Assert.IsNotNull(network);
        }

        [TestMethod]
        public void TestCodeGen()
        {
            var codeGenInstance = InstanceFactory.CodeGenInstance;
            var gen = codeGenInstance.Generate(network);
            Assert.IsNotNull(gen?.Text);
            Debug.WriteLine(gen.Text);
        }

        [TestMethod]
        public void TestImmutableClone()
        {
            var networkParam = NetworkParameter();
            var trainLayer = InputLayer(name: "train");
            var network = Network("Demo", networkParam, trainLayer)
                .AddLayer(ConvolutionalLayer(name: "conv1", input: "train"))
                .AddLayer(PoolingLayer(name: "pool1", input: "conv1"))
                .AddLayer(ConvolutionalLayer(name: "conv2", input: "conv1"));

            Assert.IsNotNull(network.Root);
            Console.WriteLine(InstanceFactory.CodeGenInstance.Generate(network).Text);
        }

        [TestMethod]
        public void TestFindChild()
        {
            var node = network.FindLayerByName("conv3");
            Assert.IsNotNull(node);
        }


    }
}
