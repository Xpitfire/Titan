﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class EltwiseLayerVertex : LayerVertex
    {
        public EltwiseOperationKind OperationKind { get; internal set; }

        internal EltwiseLayerVertex() : this(null) { }
        internal EltwiseLayerVertex(string name) : base(VertexKind.Eltwise, name) { }
    }

    [Serializable]
    public enum EltwiseOperationKind
    {
        Multiply,
        Add
    }
}
