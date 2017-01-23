using System;
using Titan.Core.Communication;
using Titan.Core.Syntax;

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
