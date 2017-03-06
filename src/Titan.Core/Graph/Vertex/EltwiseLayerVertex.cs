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
        private EltwiseLayerVertex() : this(null) { }
        public EltwiseLayerVertex(string name) : base(VertexKind.Eltwise, name)
        {
        }
    }
}