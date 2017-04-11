using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Service.Communication;

namespace Titan.Plugin.Caffe.Test
{
    [TestClass]
    public class RestApiTest
    {
        [TestMethod]
        public void TestSendMessage()
        {
            var communication = new Comm.REST.Communication();
            var rsp = communication.SendAsync("Test").Result;
            Assert.AreEqual(rsp, Response.Successful);
        }
    }
}
