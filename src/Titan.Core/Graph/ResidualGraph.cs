using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;
using Titan.Core.Syntax;

namespace Titan.Core.Graph
{
    [Serializable]
    public class ResidualGraph
    {
        public Identifier InputNode { get; internal set; }
        public ImmutableList<Identifier> LeftBranch { get; internal set; }
        public ImmutableList<Identifier> RightBranch { get; internal set; }
        public Identifier OutputNode { get; internal set; }
        
    }
}
