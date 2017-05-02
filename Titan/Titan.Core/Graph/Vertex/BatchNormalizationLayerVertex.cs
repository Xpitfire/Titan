using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class BatchNormalizationLayerVertex : LayerVertex
    {
        public bool UseGlobalStats { get; internal set; }

        internal BatchNormalizationLayerVertex() : this(null)  { }
        internal BatchNormalizationLayerVertex(string name) : base(VertexKind.BatchNormalization, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(UseGlobalStats)] = UseGlobalStats;
            return props;
        }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            return this;
        }
    }
}
