using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Core.Default;
using Titan.Core.Graph;
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
            var value = parser.Parse("network { conv (name:test in:data out:45) }");
            Assert.IsNotNull(value);
            Console.WriteLine(value.Network.Name);
        }
    }
}
