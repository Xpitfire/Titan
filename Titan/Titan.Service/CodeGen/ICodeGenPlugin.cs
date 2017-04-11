using Titan.Core.CodeGen;

namespace Titan.Service.CodeGen
{
    public interface ICodeGenPlugin : ICodeGen<CodeGenMessage>, IPlugin
    {
    }
}
