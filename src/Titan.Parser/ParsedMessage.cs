using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.AST;

namespace Titan.Parser
{
    [Serializable]
    public class ParsedMessage
    {
        public string MessageText { get; set; }
        public INode SyntaxTree { get; set; }
        public string ParserName { get; set; }
        public DateTime ParseDate { get; set; }
    }
}
