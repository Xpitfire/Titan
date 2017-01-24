using System;
using System.Collections.Immutable;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : LayerSyntax
    {
        public ImmutableArray<LayerSyntax> Layers { get; }

        internal ResidualLayerSyntax() : base(SyntaxKind.Residual) { }
        internal ResidualLayerSyntax(ImmutableArray<LayerSyntax> layers) : base(SyntaxKind.Residual)
        {
            Layers = layers;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
