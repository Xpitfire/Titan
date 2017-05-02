using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
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
                Name = "mnist-test",
                TrainPath = "/container/demo/train",
                TestPath = "/container/demo/test",
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

        private async Task<JobStatus> TestDatasetStatus(Dataset dataset)
        {
            var response = await _communication.GetJobStatusAsync(dataset);
            Assert.IsTrue(response.Type == ResponseType.Successful
                && response.Data.Type != null);
            return response.Data;
        }

        private void WaitForStatusComplete(string jobId)
        {
            var eventFired = false;
            _communication.JobCompletedEvent += id =>
            {
                if (jobId == id)
                    eventFired = true;
            };
            // wait for done or timeout stop
            while (!eventFired) ;
        }

        private async Task<Model.Model> TestClassification(Dataset dataset)
        {
            var model = new Model.Model()
            {
                Name = "lenet-test",
                DatasetId = dataset.Id,
                Network = File.ReadAllText("lenet.prototxt")
            };
            var response = await _communication.CreateClassificationModelAsync(model);
            Assert.IsTrue(response.Type == ResponseType.Successful
                && model.Id != null);
            return model;
        }

        [TestMethod, Timeout(120000)] // timeout 120 sec.
        public async Task IngerationTestCaffeApi()
        {
            await TestLogin();
            var dataset = await TestCreateDataset();
            var status = await TestDatasetStatus(dataset);
            // blocks up to 60 seconds
            WaitForStatusComplete(dataset.Id);
            // blocks up to 60 seconds
            var model = await TestClassification(dataset);
            WaitForStatusComplete(model.Id);
        }

    }
}
