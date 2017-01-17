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
            Console.WriteLine(parser.Parse(new NetworkRoot()));
        }
    }
}
