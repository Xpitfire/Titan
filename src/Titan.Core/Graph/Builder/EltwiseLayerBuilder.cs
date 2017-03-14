using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public class EltwiseLayerBuilder : GraphBuilderBase
    {
        private LayerBuilder _builder;
        private LayerBuilder _left;
        private LayerBuilder _right;

        public EltwiseLayerBuilder(LayerBuilder builder, LayerBuilder left, LayerBuilder right) : base(builder.Graph)
        {
            this._builder = builder;
            this._left = left;
            this._right = right;
        }

        internal LayerBuilder AddEltwise(EltwiseLayerVertex vertex)
        {
            base.AddVertex(vertex);
            base.AddEdge(_left.PreviousId, vertex.Identifier);
            base.AddEdge(_right.PreviousId, vertex.Identifier);
            return new LayerBuilder(this, vertex.Identifier);
        }
    }
}
