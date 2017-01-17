using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Communication
{
    public interface ICommunication<in TSendMessage, out TReceiveMessage>
    {
        event MessageDelegate<TReceiveMessage> MessageReceivedEvent;
        
        void Send(TSendMessage message);
        Task SendAsync(TSendMessage message);
    }

    public delegate void MessageDelegate<in TMessage>(TMessage message);
}
