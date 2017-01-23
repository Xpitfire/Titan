using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.Syntax.Type;

namespace Titan.Core.Parser
{
    public interface IParser<TMessage> where TMessage : ParserMessage
    {
        event MessageDelegate<TMessage> MessageParsedEvent;
        
        Task<TMessage> ParseAsync(string source);
    }
}
