using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.Syntax.Type;

namespace Titan.Core.CodeGen
{
    public interface ICodeGen<TMessage> where TMessage : CodeGenMessage
    {
        event MessageDelegate<TMessage> CodeGeneratedEvent;

        Task<TMessage> GenerateAsync(NetworkSyntax network);
    }
}
