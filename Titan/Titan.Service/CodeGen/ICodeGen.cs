using Titan.Core.Graph;
using Titan.Service.Communication;

namespace Titan.Service.CodeGen
{
    public interface ICodeGen<out TMessage> where TMessage : CodeGenMessage
    {
        event MessageDelegate<TMessage> CodeGeneratedEvent;

        TMessage Generate(Network network);
    }
}
