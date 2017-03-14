using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public class LayerBuilder : GraphBuilderBase
    {
        private NetworkBuilder _networkBuilder;

        public LayerBuilder() : base() { }
        public LayerBuilder(NetworkBuilder builder, Identifier parentId) : base(builder.Graph)
        {
            _networkBuilder = builder;
            PreviousId = parentId;
        }
        public LayerBuilder(GraphBuilderBase graphBuilder, Identifier parentId) : base(graphBuilder.Graph)
        {
            PreviousId = parentId;
        }
        
        public LayerBuilder AddLayer(LayerVertex layer)
        {
            base.AddVertex(layer);
            base.AddEdge(PreviousId, layer.Identifier);
            PreviousId = layer.Identifier;
            return this;
        }

        public LayerBuilder AddLayerSequence(params LayerVertex[] vertices)
        {
            foreach (var vertex in vertices)
            {
                AddLayer(vertex);
            }
            return this;
        }

        public LayerBuilder AddLayerBlock(Func<LayerBlockBuilder, LayerBlockBuilder> builder)
        {
            var layer = builder(new LayerBlockBuilder(this, PreviousId)).Build();
            base.AddEdge(PreviousId, layer.Identifier);
            PreviousId = layer.Identifier;
            return this;
        }

        public EltwiseLayerBuilder AddResidualBlock(Func<LayerBuilder, LayerBuilder> left, Func<LayerBuilder, LayerBuilder> right)
        {
            return new EltwiseLayerBuilder(this, 
                left(new LayerBuilder(this, base.PreviousId)), 
                right(new LayerBuilder(this, base.PreviousId)));
        }
        
        public LayerBuilder AddActivation(ActivationLayerVertex layer)
        {

            return null;
        }

        public Network BuildNetwork()
        {
            return _networkBuilder.Build();
        }

    }
}
