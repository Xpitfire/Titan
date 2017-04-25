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

        public const string DefaultBaseUri = "http://172.25.4.83:5000/";
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

                request.AddParameter("method", "standard");
                request.AddParameter("standard_networks", "lenet");
                request.AddParameter("train_epochs", "30");
                request.AddParameter("framework", "caffe");
                request.AddParameter("model_name", model.Name);
                request.AddParameter("dataset", model.Dataset.Id);
                request.AddParameter("select_gpu_count", "2");
                request.AddParameter("select_gpu", "0");
                request.AddParameter("select_gpu", "1");

                var response = client.Execute(request);
                var result = EvaluateResponse<string>(response);

                // TODO

                return result;
            });
        }

        public async Task<ResponseMessage<string>> CreateClassificationDatasetAsync(Dataset dataset)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient("/datasets/images/classification.json");
                var request = CreateRequest();

                request.AddParameter("folder_train", dataset.Path);
                request.AddParameter("encoding", dataset.Encoding);
                request.AddParameter("resize_channels", dataset.Channels);
                request.AddParameter("resize_width", dataset.Width);
                request.AddParameter("resize_height", dataset.Height);
                request.AddParameter("method", "folder");
                request.AddParameter("dataset_name", dataset.Name);

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

        public async Task<ResponseMessage<DatasetStatus>> GetJobStatusAsync(Dataset dataset)
        {
            return await Task.Run(() =>
            {
                var client = CreateClient($"/datasets/{dataset.Id}/status");
                var request = CreateRequest(Method.GET);
                
                var response = client.Execute(request);
                var result = EvaluateResponse<DatasetStatus>(response);

                var data = JsonConvert.DeserializeObject<DatasetStatus>(response.Content);
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

        private void MonitorDatasetJobStatus(Dataset dataset)
        {
            // Define the cancellation token.
            var source = new CancellationTokenSource();
            var token = source.Token;

            var monitor = PeriodicTaskFactory.Start(() =>
            {
                var response = default(ResponseMessage<DatasetStatus>);
                if ((response = GetJobStatusAsync(dataset).Result).Data
                    .Status == DatasetStatusType.Done)
                {
                    source.Cancel();
                }
            }, 
            intervalInMilliseconds: 2000,
            duration: 60000 * 60,  // wait for max. 1 hour until abort
            cancelToken: token);

            monitor.ContinueWith(_ =>
            {
                JobCompletedEvent?.Invoke(dataset.Id);
            });
        }

        private void NotifyJobCompleted()
        {

        }
    }
}
