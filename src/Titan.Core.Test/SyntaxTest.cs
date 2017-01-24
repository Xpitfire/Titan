using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Core.Default;
using Titan.Core.Syntax;

namespace Titan.Core.Test
{
    [TestClass]
    public class SyntaxTest
    {
        [TestMethod]
        public void TestSpix()
        {
            var spix = SyntaxFactory.Spix();
            Console.WriteLine(spix.Name);
            Assert.IsTrue(spix.Length > 0);
        }

        [TestMethod]
        public void TestNodeClone()
        {
            var network = SyntaxFactory
                .Network(SyntaxFactory.NetworkParameter())
                .AddLayers(SyntaxFactory.InputLayer(SyntaxFactory.InputMatrix()));
            Assert.IsNotNull(network);
        }

        [TestMethod]
        public void TestCodeGen()
        {
            var codeGenInstance = InstanceFactory.CodeGenInstance;
            var network = SyntaxFactory.Network();
            var gen = codeGenInstance.GenerateAsync(network);
            Assert.IsNotNull(gen?.Text);
        }
    }
}
