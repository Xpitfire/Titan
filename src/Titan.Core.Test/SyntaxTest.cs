using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Core.Syntax;
using Titan.Core.Syntax.Type;

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
    }
}
