using System;
using System.Threading.Tasks;
using RestSharp;
using Titan.Service.Communication;
using System.Collections.Generic;
using Titan.Core.Graph;
using Titan.Model;
using Newtonsoft.Json;

namespace Titan.Plugin.Caffe.Comm.REST
{
    public class Communication : ICommunicationPlugin
    {
        public const string BaseUri = "http://localhost:5000";
        private System.Net.CookieContainer Cookies = new System.Net.CookieContainer();

        public async Task<ResponseMessage<string>> LoginAsync(string username, string passwordHash)
        {
            return await Task.Run(() =>
            {
                var client = new RestClient($"{BaseUri}/login")
                {
                    CookieContainer = Cookies
                };
                var request = new RestRequest(Method.POST);
                request.AddParameter("username", $"{username}");
                var response = client.Execute(request);
                return Evaluate(response);
            });
        }

        public async Task<ResponseMessage<string>> CreateClassificationModelAsync(Network model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseMessage<string>> CreateClassificationDatasetAsync(Dataset dataset)
        {
            return await Task.Run(() =>
            {
                var client = new RestClient($"{BaseUri}/datasets/images/classification.json")
                {
                    CookieContainer = Cookies
                };
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("folder_train", dataset.Path);
                request.AddParameter("encoding", dataset.Encoding);
                request.AddParameter("resize_channels", dataset.Channels);
                request.AddParameter("resize_width", dataset.Width);
                request.AddParameter("resize_height", dataset.Height);
                request.AddParameter("method", "folder");
                request.AddParameter("dataset_name", dataset.Name);

                var response = client.Execute(request);
                var result = Evaluate(response);

                var data = JsonConvert.DeserializeObject<Dataset>(response.Content);
                dataset.Id = data?.Id;

                result.Data = dataset.Id;
                return result;
            });
        }

        public async Task<ResponseMessage<string>> PostAsync(string message, string uriPath, IDictionary<string, string> headerParams)
        {
            return await Task.Run(() =>
            {
                var client = new RestClient($"{BaseUri}{uriPath ?? string.Empty}");
                var request = new RestRequest(Method.POST);

                if (headerParams != null)
                {
                    foreach (var key in headerParams.Keys)
                    {
                        request.AddHeader(key, headerParams[key]);
                    }
                }
                request.AddBody(message);
                var response = client.Execute(request);
                var result = Evaluate(response);
                return result;
            });
        }

        private ResponseMessage<string> Evaluate(IRestResponse response)
        {
            var result = new ResponseMessage<string>();
            if (response.StatusCode != System.Net.HttpStatusCode.OK  || response.ErrorException != null)
            {
                result.Type = ResponseType.Failed;
            }
            else
            {
                result.Data = response.Content;
                result.Type = ResponseType.Successful;
            }
            return result;
        }
        
    }
}
