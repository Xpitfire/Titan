using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Titan.Communication;
using Titan.Core.Communication;
using Titan.Core.Parser;
using Titan.Plugin.Communication;

namespace Titan.Plugin.Caffe.Communication.REST
{
    public class Communication : MarshalByRefObject, ICommunicationPlugin
    {
        public event MessageDelegate<string> MessageReceivedEvent;
        
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
