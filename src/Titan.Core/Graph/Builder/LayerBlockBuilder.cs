using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public class LayerBlockBuilder : GraphBuilderBase
    {
        private LayerVertex _layer;

        public LayerBlockBuilder(GraphBuilderBase layerBuilder) : base(layerBuilder.Graph)
        {
            PreviousId = layerBuilder.PreviousId;
        }

        public LayerBlockBuilder AddLayer(LayerVertex layer)
        {
            _layer = layer;
            base.AddVertex(layer);
            return this;
        }

        public LayerBlockBuilder AddActivation(ActivationLayerVertex layer)
        {
            base.AddVertex(layer);
            base.AddEdge(_layer.Identifier, layer.Identifier, cycle: true);
            return this;
        }
        public LayerBlockBuilder AddBatchNorm(BatchNormalizationLayerVertex layer)
        {
            base.AddVertex(layer);
            base.AddEdge(_layer.Identifier, layer.Identifier, cycle: true);
            return this;
        }
        public LayerBlockBuilder AddScale(ScaleLayerVertex layer)
        {
            base.AddVertex(layer);
            base.AddEdge(_layer.Identifier, layer.Identifier, cycle: true);
            return this;
        }

        public LayerVertex Build()
        {
            if (_layer == null) throw new InvalidOperationException();
            return _layer;
        }

    }
}
