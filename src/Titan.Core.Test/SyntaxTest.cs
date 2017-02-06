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
            InputLayer(InputLayerKind.Train, "train"),
            InputLayer(InputLayerKind.Validation, "val"),
            InputLayer(InputLayerKind.Test, "test"))
            .AddLayer(ConvolutionalLayer("conv1"))
            .AddLayer(ConvolutionalLayer("conv2"))
            .AddLayer(ConvolutionalLayer("conv3"))
            .AddLayer(ConvolutionalLayer())
            .AddLayer(ConvolutionalLayer())
            .AddOutputLayers(OutputLayer("output"));

        [TestMethod]
        public void TestIdentifier()
        {
            var identifier = Identifier();
            Console.WriteLine(identifier.Id);
            Assert.IsNotNull(identifier.Id);
        }

        [TestMethod]
        public void TestNodeClone()
        {
            var network = Network(NetworkParameter())
                .AddInputLayers(InputLayer(InputLayerKind.Train, Syntax.Data.Empty, Label.Empty));
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
            var trainLayer = InputLayer(InputLayerKind.Train);
            var network = Network(networkParam, trainLayer)
                .AddLayer(ConvolutionalLayer())
                .AddLayer(PoolingLayer())
                .AddLayer(ConvolutionalLayer());

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
