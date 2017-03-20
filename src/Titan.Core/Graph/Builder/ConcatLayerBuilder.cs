using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public class ConcatLayerBuilder : GraphBuilderBase
    {
        private readonly LayerBuilder[] _builders;

        public ConcatLayerBuilder(GraphBuilderBase parentLayerBuilder, params LayerBuilder[] builders) : base(parentLayerBuilder.Graph)
        {
            _builders = builders;
        }

        public LayerBuilder AddConcat(ConcatLayerVertex concatLayerVertex)
        {
            base.AddVertex(concatLayerVertex);
            foreach (var builder in _builders)
            {
                base.AddEdge(builder.PreviousId, concatLayerVertex.Identifier);
            }
            return new LayerBuilder(this);
        }

    }
}
