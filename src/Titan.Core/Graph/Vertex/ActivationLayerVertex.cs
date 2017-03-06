using System;
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

        private ActivationLayerVertex() : this(null) { }
        public ActivationLayerVertex(string name, 
            ActivationFunctionType activationFunction = ActivationFunctionType.ReLU) : base(VertexKind.Activation, name)
        {
            ActivationFunction = activationFunction;
        }
    }

    public enum ActivationFunctionType
    {
        ReLU,
        Sigmoid,
        TanH
    }
}
