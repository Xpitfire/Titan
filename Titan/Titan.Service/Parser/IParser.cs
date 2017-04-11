using Titan.Service.Communication;

namespace Titan.Service.Parser
{
    public interface IParser<out TMessage> where TMessage : ParserMessage
    {
        event MessageDelegate<TMessage> MessageParsedEvent;
        
        TMessage Parse(string source);
    }
}
