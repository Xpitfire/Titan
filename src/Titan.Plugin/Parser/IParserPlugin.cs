using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.AST;
using Titan.Parser;

namespace Titan.Plugin.Parser
{
    public interface IParserPlugin : IParser, IPlugin
    {
    }
}
