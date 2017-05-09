using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ScaleLayerVertex : LayerVertex, IAttachableLayer
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

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            bool.TryParse(properties[nameof(BiasTerm)].ToString(), out bool biasTerm);
            BiasTerm = biasTerm;
            return this;
        }
    }
}
