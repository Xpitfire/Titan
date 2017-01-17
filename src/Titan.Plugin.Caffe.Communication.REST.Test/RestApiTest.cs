using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Parser;

namespace Titan.Plugin.Caffe.Communication.REST.Test
{
    [TestClass]
    public class RestApiTest
    {
        [TestMethod]
        public void TestSendMessage()
        {
            var communication = new Communication();
            communication.Send(new ParsedMessage());
        }
    }
}
