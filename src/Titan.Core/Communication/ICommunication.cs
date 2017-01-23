using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Communication;

namespace Titan.Communication
{
    public interface ICommunication<in TSendMessage, out TReceiveMessage>
    {
        event MessageDelegate<TReceiveMessage> MessageReceivedEvent;

        Task<Response> SendAsync(TSendMessage message);
    }

    public delegate void MessageDelegate<in TMessage>(TMessage message);
}
