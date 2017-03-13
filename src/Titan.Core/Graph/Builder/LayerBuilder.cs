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
        internal LayerBuilder(NetworkBuilder builder, Identifier parentId) : base(builder.Graph)
        {
            _networkBuilder = builder;
            PreviousId = parentId;
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
            var layer = builder(new LayerBlockBuilder(this, PreviousId)).Build();
            base.AddEdge(PreviousId, layer.Identifier);
            PreviousId = layer.Identifier;
            return this;
        }

        public EltwiseLayerBuilder AddResidualBlock(Func<ResidualBlockLeftBuilder, LayerBuilder> left, Func<ResidualBlockRightBuilder, LayerBuilder> right)
        {
            // TODO correct
            return new EltwiseLayerBuilder();
        }

        public LayerBuilder AddSequence(Func<SequenceBuilder, LayerBuilder> builder)
        {
            // TODO correct
            return null;
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
