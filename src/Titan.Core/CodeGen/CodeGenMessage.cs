using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Communication;
using Titan.Core.Syntax;

namespace Titan.Core.CodeGen
{
    [Serializable]
    public class CodeGenMessage : Message<NetworkSyntax>
    {
        public string Text { get; set; }
        public string CodeGenName { get; set; }
        public DateTime CodeGenDate { get; set; }
    }
}
