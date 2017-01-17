using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Core.AST;
using Titan.Parser;
using Titan.Plugin.Parser;

namespace Titan.Core.Test
{
    [TestClass]
    public class PluginTest
    {
        [TestMethod]
        public void TestInstanceLoader()
        {
            var parser = PluginFactory.Get<IParserPlugin>();
            Assert.IsNotNull(parser);
            var value = parser.Parse(new NetworkRoot());
            Assert.IsNotNull(value);

            Console.WriteLine(value.Data);
        }
    }
}
