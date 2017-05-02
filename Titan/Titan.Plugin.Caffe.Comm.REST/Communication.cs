using System;
using System.Threading.Tasks;
using RestSharp;
using Titan.Service.Communication;
using System.Collections.Generic;
using Titan.Model;
using Newtonsoft.Json;
using Titan.Service.Task;
using System.Threading;

namespace Titan.Plugin.Caffe.Comm.REST
{
    public class Communication : ICommunicationPlugin
    {
        public event MessageDelegate<string> JobCompletedEvent;

        public const string DefaultBaseUri = 
        //    "http://172.25.4.83:5000/";
            "http://127.0.0.1:5000/";

        private string BaseUri;
        private System.Net.CookieContainer Cookies = new System.Net.CookieContainer();

        public Communication(string baseUri = null)
        {
            BaseUri = baseUri ?? DefaultBaseUri;
        }

        public async Task<ResponseMessage<string>> LoginAsync(string username, string passwordHash = null)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient("/login");
                var request = CreateRequest();

                request.AddParameter("username", $"{username}");

                var response = client.Execute(request);

                var result = EvaluateResponse<string>(response);
                result.Data = username;

                return result;
            });
        }

        public async Task<ResponseMessage<string>> CreateClassificationModelAsync(Model.Model model)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient("/models/images/classification.json");
                var request = CreateRequest();

                // model
                request.AddParameter("model_name", model.Name);
                request.AddParameter("dataset", model.DatasetId);
                request.AddParameter("group_name", "generated");

                // network
                request.AddParameter("method", "custom");
                request.AddParameter("framework", "caffe");
                request.AddParameter("custom_network", model.Network);

                // network global params
                request.AddParameter("train_epochs", "10");
                request.AddParameter("snapshot_interval", "1");
                request.AddParameter("val_interval", "1");
                request.AddParameter("random_seed", "");

                // batch
                request.AddParameter("batch_size", "50");

                // solver
                request.AddParameter("solver_type", "SGD");
                request.AddParameter("rms_decay", "0.99");

                // learning rate
                request.AddParameter("learning_rate", "0.01");
                request.AddParameter("lr_policy", "step");
                request.AddParameter("lr_step_size", "33");
                request.AddParameter("lr_step_gamma", "0.1");
                request.AddParameter("lr_multistep_gamma", "0.5");
                request.AddParameter("lr_exp_gamma", "0.95");
                request.AddParameter("lr_inv_gamma", "0.1");
                request.AddParameter("lr_inv_power", "0.5");
                request.AddParameter("lr_poly_power", "3");
                request.AddParameter("lr_sigmoid_step", "50");
                request.AddParameter("lr_sigmoid_gamma", "0.1");

                // image
                request.AddParameter("use_mean", "image");

                // gpu
                if (model.UseGpu)
                {
                    request.AddParameter("select_gpu_count", model.GpuCount);
                }

                var response = client.Execute(request);
                var result = EvaluateResponse<string>(response);
                var data = JsonConvert.DeserializeObject<Model.Model>(response.Content);
                model.Id = data?.Id;
                result.Data = model.Id;

                if (model.Id == null)
                    throw new InvalidJobException($"Received Null for Id: {response.Content}");

                MonitorModelJobStatus(model);

                return result;
            });
        }

        public async Task<ResponseMessage<string>> CreateClassificationDatasetAsync(Dataset dataset)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient("/datasets/images/classification.json");
                var request = CreateRequest();

                // dataset
                request.AddParameter("dataset_name", dataset.Name);
                request.AddParameter("group_name", "generated");
                request.AddParameter("method", "folder");
                request.AddParameter("backend", "lmdb");

                // test & train params
                request.AddParameter("folder_train", dataset.TrainPath);
                request.AddParameter("folder_test", dataset.TestPath);
                request.AddParameter("has_test_folder", "y");

                // image params
                request.AddParameter("resize_channels", dataset.Channels);
                request.AddParameter("resize_width", dataset.Width);
                request.AddParameter("resize_height", dataset.Height);
                request.AddParameter("resize_mode", "squash");
                request.AddParameter("encoding", dataset.Encoding);
                request.AddParameter("compression", "none");

                var response = client.Execute(request);
                var result = EvaluateResponse<string>(response);

                var data = JsonConvert.DeserializeObject<Dataset>(response.Content);
                dataset.Id = data?.Id;
                result.Data = dataset.Id;

                if (dataset.Id == null)
                    throw new InvalidJobException($"Received Null for Id: {response.Content}");

                MonitorDatasetJobStatus(dataset);

                return result;
            });
        }

        public async Task<ResponseMessage<JobStatus>> GetJobStatusAsync(Dataset dataset)
        {
            return await GetJobStatusAsync($"/datasets/{dataset.Id}/status");
        }

        public async Task<ResponseMessage<JobStatus>> GetJobStatusAsync(Model.Model model)
        {
            return await GetJobStatusAsync($"/models/{model.Id}/status");
        }

        private async Task<ResponseMessage<JobStatus>> GetJobStatusAsync(string uri)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient(uri);
                var request = CreateRequest(Method.GET);

                var response = client.Execute(request);
                var result = EvaluateResponse<JobStatus>(response);

                var data = JsonConvert.DeserializeObject<JobStatus>(response.Content);
                result.Data = data;

                return result;
            });
        }

        public async Task<ResponseMessage<string>> PostAsync(string message, string uriPath, IDictionary<string, string> headerParams)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient(uriPath);
                var request = CreateRequest();
                if (headerParams != null)
                {
                    foreach (var key in headerParams.Keys)
                    {
                        request.AddHeader(key, headerParams[key]);
                    }
                }
                request.AddBody(message);
                var response = client.Execute(request);
                var result = EvaluateResponse<string>(response);
                return result;
            });
        }

        private RestClient CreateClient(string uriPath)
        {
            var client = new RestClient($"{BaseUri}{uriPath ?? string.Empty}")
            {
                CookieContainer = Cookies
            };
            var request = new RestRequest(Method.POST);
            return client;
        }

        private RestRequest CreateRequest(Method type = Method.POST)
        {
            var request = new RestRequest(type);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            return request;
        }

        private ResponseMessage<T> EvaluateResponse<T>(IRestResponse response)
        {
            var result = new ResponseMessage<T>();
            if (response.StatusCode != System.Net.HttpStatusCode.OK  || response.ErrorException != null)
            {
                result.Type = ResponseType.Failed;
            }
            else
            {
                result.Type = ResponseType.Successful;
            }
            return result;
        }

        private void MonitorModelJobStatus(Model.Model model)
        {
            // Define the cancellation token.
            var source = new CancellationTokenSource();
            var token = source.Token;

            MonitorJobStatus(() =>
            {
                var response = default(ResponseMessage<JobStatus>);
                if ((response = GetJobStatusAsync(model).Result).Data
                    .Status == DatasetStatusType.Done)
                {
                    source.Cancel();
                }
            }, model.Id, token);
        }

        private void MonitorDatasetJobStatus(Dataset dataset)
        {
            // Define the cancellation token.
            var source = new CancellationTokenSource();
            var token = source.Token;

            MonitorJobStatus(() =>
            {
                var response = default(ResponseMessage<JobStatus>);
                if ((response = GetJobStatusAsync(dataset).Result).Data
                    .Status == DatasetStatusType.Done)
                {
                    source.Cancel();
                }
            }, dataset.Id, token);
        }

        private void MonitorJobStatus(Action job, string id, CancellationToken token)
        {
            var monitor = PeriodicTaskFactory.Start(job,
            intervalInMilliseconds: 2000,
            duration: 60000 * 60,  // wait for max. 1 hour until abort
            cancelToken: token);
            monitor.ContinueWith(_ =>
            {
                JobCompletedEvent?.Invoke(id);
            });
        }

        private void NotifyJobCompleted()
        {

        }
    }
}
