using System;
using Titan.Core.Communication;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.CodeGen
{
    [Serializable]
    public class CodeGenMessage : Message<Network>
    {
        public string Text { get; set; }
        public string CodeGenName { get; set; }
        public DateTime CodeGenDate { get; set; } = DateTime.Now;
    }
}
