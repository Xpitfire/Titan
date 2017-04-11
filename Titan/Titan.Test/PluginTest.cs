using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Default;
using Titan.Service.Parser;

namespace Titan.Test
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
