using System;
using Titan.Core.Communication;
using Titan.Core.Syntax;

namespace Titan.Core.CodeGen
{
    [Serializable]
    public class CodeGenMessage : Message<NetworkSyntax>
    {
        public string Text { get; set; }
        public string CodeGenName { get; set; }
        public DateTime CodeGenDate { get; set; } = DateTime.Now;
    }
}
