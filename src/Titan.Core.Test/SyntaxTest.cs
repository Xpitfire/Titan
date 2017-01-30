using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Core.Default;
using Titan.Core.Syntax;
using System.Diagnostics;

namespace Titan.Core.Test
{
    [TestClass]
    public class SyntaxTest
    {
        [TestMethod]
        public void TestSpix()
        {
            var spix = SyntaxFactory.Spix();
            Console.WriteLine(spix.Id);
            Assert.IsNotNull(spix.Id);
        }

        [TestMethod]
        public void TestNodeClone()
        {
            var network = SyntaxFactory
                .Network(SyntaxFactory.NetworkParameter())
                .AddInputLayers(SyntaxFactory.InputLayer(InputLayerType.Train, Data.Empty, Label.Empty));
            Assert.IsNotNull(network);
        }

        [TestMethod]
        public void TestCodeGen()
        {
            var codeGenInstance = InstanceFactory.CodeGenInstance;
            var network = SyntaxFactory.Network("Demo");
            network = network.AddInputLayers(
                SyntaxFactory.InputLayer(InputLayerType.Train, "train"),
                SyntaxFactory.InputLayer(InputLayerType.Validation, "val"),
                SyntaxFactory.InputLayer(InputLayerType.Test, "test"));
            network = network
                .AddLayer(SyntaxFactory.ConvolutionalLayer("conv1"))
                .AddLayer(SyntaxFactory.ConvolutionalLayer("conv2"));
            var gen = codeGenInstance.Generate(network);
            Assert.IsNotNull(gen?.Text);
            Debug.WriteLine(gen.Text);
        }

        [TestMethod]
        public void TestImmutableClone()
        {
            var networkParam = SyntaxFactory.NetworkParameter();
            var trainLayer = SyntaxFactory.InputLayer(InputLayerType.Train);
            
            var network = SyntaxFactory.Network(networkParam, trainLayer)
                .AddLayer(SyntaxFactory.ConvolutionalLayer())
                .AddLayer(SyntaxFactory.PoolingLayer())
                .AddLayer(SyntaxFactory.ConvolutionalLayer());
            
            Assert.IsNotNull(network.Layers);
            Console.WriteLine(InstanceFactory.CodeGenInstance.Generate(network).Text);
        }
    }
}
