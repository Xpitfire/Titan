using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Plugin.Caffe.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestLeNetSuccessParser()
        {
            var parser = new Parser.Parser();
            parser.Parse(@"CaffeTests\LeNet.prototxt");
        }

        [TestMethod]
        public void TestResNet50DeploySuccessParser()
        {
            var parser = new Parser.Parser();
            parser.Parse(@"CaffeTests\ResNet-50-deploy.prototxt");
        }

        [TestMethod]
        public void TestAlexNetSuccessParser()
        {
            var parser = new Parser.Parser();
            parser.Parse(@"CaffeTests\AlexNet.prototxt");
        }

        [TestMethod]
        public void TestGoogLeNetSuccessParser()
        {
            var parser = new Parser.Parser();
            parser.Parse(@"CaffeTests\GoogLeNet.prototxt");
        }

        [TestMethod]
        public void TestGoogLeNetDeploySuccessParser()
        {
            var parser = new Parser.Parser();
            parser.Parse(@"CaffeTests\GoogLeNet-deploy.prototxt");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestErrorParser()
        {
            var parser = new Parser.Parser();
            parser.Parse(@"CaffeTests\Error.prototxt");
        }

    }
}
