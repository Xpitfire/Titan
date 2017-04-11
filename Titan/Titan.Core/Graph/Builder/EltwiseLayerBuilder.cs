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
        private readonly LayerBuilder _leftLayerBuilder;
        private readonly LayerBuilder _rightLayerBuilder;

        public EltwiseLayerBuilder(GraphBuilderBase parentLayerBuilder, LayerBuilder leftLayerBuilder, LayerBuilder rightLayerBuilder) : base(parentLayerBuilder.Graph)
        {
            _leftLayerBuilder = leftLayerBuilder;
            _rightLayerBuilder = rightLayerBuilder;
        }

        public LayerBuilder AddEltwise(EltwiseLayerVertex eltwiseLayerVertex)
        {
            base.AddVertex(eltwiseLayerVertex);
            base.AddEdge(_leftLayerBuilder.PreviousId, eltwiseLayerVertex.Identifier);
            base.AddEdge(_rightLayerBuilder.PreviousId, eltwiseLayerVertex.Identifier);
            PreviousId = eltwiseLayerVertex.Identifier;
            return new LayerBuilder(this);
        }
    }
}
