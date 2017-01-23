using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.CodeGen;

namespace Titan.Plugin.CodeGen
{
    public interface ICodeGenPlugin : ICodeGen<CodeGenMessage>, IPlugin
    {
    }
}
