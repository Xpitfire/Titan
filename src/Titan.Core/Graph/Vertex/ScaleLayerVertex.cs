using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ScaleLayerVertex : LayerVertex
    {
        public bool BiasTerm { get; internal set; }

        internal ScaleLayerVertex() : this(null) { }
        internal ScaleLayerVertex(string name) : base(VertexKind.Scaling, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(BiasTerm)] = BiasTerm;
            return props;
        }
    }
}
