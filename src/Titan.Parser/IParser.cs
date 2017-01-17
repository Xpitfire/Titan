using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.AST;

namespace Titan.Parser
{
    public interface IParser<TMessage>
    {
        event MessageDelegate<TMessage> MessageParsedEvent;

        TMessage Parse(INode root);
        Task<TMessage> ParseAsync(INode root);
    }
}
