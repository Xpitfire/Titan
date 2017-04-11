using System;
using Titan.Core.Graph;
using Titan.Service.Communication;

namespace Titan.Service.CodeGen
{
    [Serializable]
    public class CodeGenMessage : Message<Network>
    {
        public string Text { get; set; }
        public string CodeGenName { get; set; }
        public DateTime CodeGenDate { get; set; } = DateTime.Now;
    }
}
