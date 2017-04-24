using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Titan.Model;
using Titan.Service.Communication;

namespace Titan.Plugin.Caffe.Test
{
    [TestClass]
    public class RestApiTest
    {
        private readonly Comm.REST.Communication _communication = new Comm.REST.Communication();

        private async Task TestLogin()
        {
            var rsp = await _communication.LoginAsync("xpitfire", null);
            Assert.IsTrue(rsp.Type == ResponseType.Successful);
        }

        private async Task<Dataset> TestCreateDataset()
        {
            await TestLogin();
            var dataset = new Dataset
            {
                Name = "test",
                Path = "/root/mnist/train",
                Channels = 1,
                Height = 28,
                Width = 28,
                Encoding = "png"
            };
            var rsp = await _communication.CreateClassificationDatasetAsync(dataset);
            Assert.IsTrue(rsp.Type == ResponseType.Successful
                && dataset.Id != null);
            return dataset;
        }

        [TestMethod]
        public async Task IngerationTestCaffeApi()
        {
            var dataset = await TestCreateDataset();

        }
    }
}
