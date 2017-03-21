using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class OutputLayerVertex : LayerVertex
    {
        public int NumberOfClasses { get; internal set; }

        internal OutputLayerVertex() : this(null) { }
        internal OutputLayerVertex(string name) : base(VertexKind.Softmax, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(NumberOfClasses)] = NumberOfClasses;
            return props;
        }

    }
}
