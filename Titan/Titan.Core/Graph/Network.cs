using System;
using System.Collections.Generic;
using System.Linq;
using Titan.Core.Collection;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    [Serializable]
    public class Network
    {
        public ImmutableList<LayerVertex> Vertices { get; internal set; }
        public ImmutableList<Relationship> References { get; internal set; }

        public string Name { get; internal set; }

        internal Network() { }
    }
    
}
