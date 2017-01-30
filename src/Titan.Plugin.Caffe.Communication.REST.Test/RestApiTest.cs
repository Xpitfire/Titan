using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Core.Communication;
using Titan.Core.Parser;

namespace Titan.Plugin.Caffe.Communication.REST.Test
{
    [TestClass]
    public class RestApiTest
    {
        [TestMethod]
        public void TestSendMessage()
        {
            var communication = new Communication();
            var rsp = communication.SendAsync("Test").Result;
            Assert.AreEqual(rsp, Response.Successful);
        }
    }
}
