using System;
using System.Threading.Tasks;
using RestSharp;
using Titan.Service.Communication;

namespace Titan.Plugin.Caffe.Comm.REST
{
    public class Communication : ICommunicationPlugin
    {
        public event MessageDelegate<string> MessageReceivedEvent;
        
        // TODO: 
        public Task<Response> SendAsync(string message)
        {
            return Task.Run(() =>
            {
                var client = new RestClient("http://localhost:5000/login");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "text/html; charset=utf-8");
                request.AddHeader("Set-Cookie", "username=xpitfire; Path=/");
                var response = client.Execute(request);
                if (response == null || response.ErrorException != null) return Response.Failed;
                MessageReceivedEvent?.Invoke(response.Content);
                Console.WriteLine(response.Content);
                //SendJson();
                return Response.Successful;
            });
        }
    }
}
