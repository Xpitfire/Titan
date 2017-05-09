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
            parser.ParseCaffePrototxt(@"CaffeTests\LeNet.prototxt");
        }

        [TestMethod]
        public void TestResNet50DeploySuccessParser()
        {
            var parser = new Parser.Parser();
            parser.ParseCaffePrototxt(@"CaffeTests\ResNet-50-deploy.prototxt");
        }

        [TestMethod]
        public void TestAlexNetSuccessParser()
        {
            var parser = new Parser.Parser();
            parser.ParseCaffePrototxt(@"CaffeTests\AlexNet.prototxt");
        }

        [TestMethod]
        public void TestGoogLeNetSuccessParser()
        {
            var parser = new Parser.Parser();
            parser.ParseCaffePrototxt(@"CaffeTests\GoogLeNet.prototxt");
        }

        [TestMethod]
        public void TestGoogLeNetDeploySuccessParser()
        {
            var parser = new Parser.Parser();
            parser.ParseCaffePrototxt(@"CaffeTests\GoogLeNet-deploy.prototxt");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestErrorParser()
        {
            var parser = new Parser.Parser();
            parser.ParseCaffePrototxt(@"CaffeTests\Error.prototxt");
        }

    }
}
