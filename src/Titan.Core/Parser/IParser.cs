using System.Threading.Tasks;
using Titan.Core.Communication;

namespace Titan.Core.Parser
{
    public interface IParser<TMessage> where TMessage : ParserMessage
    {
        event MessageDelegate<TMessage> MessageParsedEvent;
        
        TMessage ParseAsync(string source);
    }
}
