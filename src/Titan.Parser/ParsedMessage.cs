using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.AST;

namespace Titan.Parser
{
    [Serializable]
    public class ParsedMessage : Message<string>
    {
        public INode SyntaxTree { get; set; }
        public string ParserName { get; set; }
        public DateTime ParseDate { get; set; }
    }
}
