using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Core.Graph
{
    [Serializable]
    public sealed class Edge
    {
        public Identifier Source { get; internal set; }
        public Identifier Target { get; internal set; }

        private Edge() { }
        public Edge(Identifier source, Identifier target)
        {
            Source = source;
            Target = target;
        }
    }
}
