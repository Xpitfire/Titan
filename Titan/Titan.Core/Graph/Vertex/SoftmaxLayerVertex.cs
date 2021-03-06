﻿using System;
using System.Collections.Generic;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class SoftmaxLayerVertex : LayerVertex, IOperationalLayer
    {
        public int NumberOfClasses { get; internal set; }

        internal SoftmaxLayerVertex() : this(null) { }
        internal SoftmaxLayerVertex(string name) : this(name, 0) { }
        public SoftmaxLayerVertex(string name, int numberOfClasses) : base(VertexKind.Softmax, name)
        {
            NumberOfClasses = numberOfClasses;
        }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(NumberOfClasses)] = NumberOfClasses;
            return props;
        }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            int.TryParse(properties[nameof(NumberOfClasses)].ToString(), out int numberOfClasses);
            NumberOfClasses = numberOfClasses;
            return this;
        }
    }
}
