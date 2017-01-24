using System.Threading.Tasks;
using Titan.Core.Communication;

namespace Titan.Core.Parser
{
    public interface IParser<out TMessage> where TMessage : ParserMessage
    {
        event MessageDelegate<TMessage> MessageParsedEvent;
        
        TMessage Parse(string source);
    }
}
