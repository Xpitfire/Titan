using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Titan.Model;
using Titan.Service.Communication;

namespace Titan.Plugin.Caffe.Test
{
    [TestClass]
    public class RestApiTest
    {
        private readonly Comm.REST.Communication _communication = 
            new Comm.REST.Communication();

        private async Task TestLogin()
        {
            var response = await _communication.LoginAsync("xpitfire");
            Assert.IsTrue(response.Type == ResponseType.Successful);
        }

        private async Task<Dataset> TestCreateDataset()
        {
            var dataset = new Dataset
            {
                Name = "test",
                Path = "/root/mnist/train",
                Channels = 1,
                Height = 28,
                Width = 28,
                Encoding = "png"
            };
            var response = await _communication.CreateClassificationDatasetAsync(dataset);
            Assert.IsTrue(response.Type == ResponseType.Successful
                && dataset.Id != null);
            return dataset;
        }

        private async Task<DatasetStatus> TestDatasetStatus(Dataset dataset)
        {
            var response = await _communication.GetJobStatusAsync(dataset);
            Assert.IsTrue(response.Type == ResponseType.Successful
                && response.Data.Type != null);
            return response.Data;
        }

        private void WaitForDatasetStatusComplete(Dataset dataset)
        {
            var eventFired = false;
            _communication.JobCompletedEvent += id =>
            {
                if (dataset.Id == id)
                    eventFired = true;
            };
            // wait for done or timeout stop
            while (!eventFired) ;
        }

        [TestMethod, Timeout(60000)] // timeout 60 sec.
        public async Task IngerationTestCaffeApi()
        {
            await TestLogin();
            var dataset = await TestCreateDataset();
            var status = await TestDatasetStatus(dataset);
            // blocks up to 60 seconds
            WaitForDatasetStatusComplete(dataset);
        }
    }
}
