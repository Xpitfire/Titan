using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Titan.Communication;
using Titan.Parser;
using Titan.Plugin.Communication;

namespace Titan.Plugin.Caffe.Communication.REST
{
    public class Communication : MarshalByRefObject, ICommunicationPlugin
    {
        public event MessageDelegate<string> MessageReceivedEvent;

        public void Send(ParsedMessage message)
        {
            SendMessage(message);
        }

        public Task SendAsync(ParsedMessage message)
        {
            return Task.Run(() => SendMessage(message));
        }

        private void SendMessage(ParsedMessage message)
        {
            var client = new RestClient("https://localhost:5000/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/html");
            request.AddHeader("Set-Cookie", "username=xpitfire; Path=/");
            var response = client.Execute(request);
            MessageReceivedEvent?.Invoke(response.Content);
        }
    }
}
