﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ActivationLayerVertex : LayerVertex
    {
        public ActivationFunctionType ActivationFunction { get; internal set; }

        internal ActivationLayerVertex() : this(null) { }
        internal ActivationLayerVertex(string name) : base(VertexKind.Activation, name) { }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(ActivationFunction)] = ActivationFunction.ToString();
            return props;
        }
    }

    public enum ActivationFunctionType
    {
        ReLU,
        Sigmoid,
        TanH
    }
}