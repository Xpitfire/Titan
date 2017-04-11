using System;
using Titan.Core.Graph;
using Titan.Service.Communication;

namespace Titan.Service.Parser
{
    [Serializable]
    public class ParserMessage : Message<string>
    {
        public Network Network { get; set; }
        public string ParserName { get; set; }
        public DateTime ParseDate { get; set; } = DateTime.Now;
    }
}
