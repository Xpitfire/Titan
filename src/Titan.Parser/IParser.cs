using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.AST;

namespace Titan.Parser
{
    public interface IParser
    {
        ParsedMessage Parse(INode root);
    }
}
