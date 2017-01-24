using System;
using System.Collections.Immutable;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : LayerSyntax
    {
        public ImmutableArray<LayerSyntax> Layers { get; }

        private ResidualLayerSyntax() : base(SyntaxKind.Residual) { }
        internal ResidualLayerSyntax(ImmutableArray<LayerSyntax> layers) : base(SyntaxKind.Residual)
        {
            Layers = layers;
        }
        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<ResidualLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }
}
