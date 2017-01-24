using System;
using System.Threading.Tasks;

namespace Titan.Core.Communication
{
    public interface ICommunication<in TSendMessage, out TReceiveMessage>
    {
        event MessageDelegate<TReceiveMessage> MessageReceivedEvent;

        Task<Response> SendAsync(TSendMessage message);
    }

    [Serializable]
    public delegate void MessageDelegate<in TMessage>(TMessage message);
}
