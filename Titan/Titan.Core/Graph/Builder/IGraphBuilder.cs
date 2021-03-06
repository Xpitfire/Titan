﻿using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public interface IGraphBuilder<TType>
    {
        IDictionary<string, TType> Vertices { get; }
        IList<Relationship> Relationships { get; }
        Identifier GraphId { get; }
        void PersistGraph();
    }
}
