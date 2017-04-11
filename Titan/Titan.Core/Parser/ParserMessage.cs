using System;
using Titan.Core.Communication;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Parser
{
    [Serializable]
    public class ParserMessage : Message<string>
    {
        public Network Network { get; set; }
        public string ParserName { get; set; }
        public DateTime ParseDate { get; set; } = DateTime.Now;
    }
}
