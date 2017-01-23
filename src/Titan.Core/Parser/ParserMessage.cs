using System;
using Titan.Communication;
using Titan.Core.Syntax.Type;

namespace Titan.Core.Parser
{
    [Serializable]
    public class ParserMessage : Message<string>
    {
        public NetworkSyntax SyntaxTree { get; set; }
        public string ParserName { get; set; }
        public DateTime ParseDate { get; set; }
    }
}
