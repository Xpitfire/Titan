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
        private readonly NetworkBuilder _networkBuilder;

        public LayerBuilder() : base() { }
        public LayerBuilder(NetworkBuilder builder) : base(builder.Graph)
        {
            _networkBuilder = builder;
            PreviousId = builder.PreviousId;
        }
        public LayerBuilder(GraphBuilderBase builder) : base(builder.Graph)
        {
            PreviousId = builder.PreviousId;
        }

        public LayerBuilder AddLayer(LayerVertex layer)
        {
            base.AddVertex(layer);
            base.AddEdge(PreviousId, layer.Identifier);
            PreviousId = layer.Identifier;
            return this;
        }

        public LayerBuilder AddLayerBlock(Func<LayerBlockBuilder, LayerBlockBuilder> builder)
        {
            var layer = builder(new LayerBlockBuilder(this)).Build();
            base.AddEdge(PreviousId, layer.Identifier);
            PreviousId = layer.Identifier;
            return this;
        }

        public EltwiseLayerBuilder AddResidualBlock(Func<LayerBuilder, LayerBuilder> left, Func<LayerBuilder, LayerBuilder> right)
        {
            return new EltwiseLayerBuilder(this, left(new LayerBuilder(this)), right(new LayerBuilder(this)));
        }

        public ConcatLayerBuilder AddInceptionBlock(params Func<LayerBuilder, LayerBuilder>[] layers)
        {
            if (layers == null || layers.Length <= 0) throw new InvalidOperationException();

            var builders = new LayerBuilder[layers.Length];
            for (var i = 0; i < layers.Length; i++)
            {
                builders[i] = layers[i](new LayerBuilder(this));
            }
            return new ConcatLayerBuilder(this, builders);
        }
        
        public LayerBuilder AddActivation(ActivationLayerVertex layer)
        {
            base.AddVertex(layer);
            base.AddEdge(PreviousId, layer.Identifier, cycle: true);
            return this;
        }

        public Network BuildNetwork()
        {
            return _networkBuilder.Build();
        }

    }
}
