using System;
using System.Collections.Immutable;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : LayerSyntax
    {
        public ImmutableArray<LayerSyntax> LeftBranch { get; internal set; }
        public ImmutableArray<LayerSyntax> RightBranch { get; internal set; }

        private ResidualLayerSyntax() : base(SyntaxKind.Residual) { }
        internal ResidualLayerSyntax(
            ImmutableArray<LayerSyntax> leftBranch, 
            ImmutableArray<LayerSyntax> rightBranch) : base(SyntaxKind.Residual)
        {
            LeftBranch = leftBranch;
            RightBranch = rightBranch;
        }
        public LayerSyntax AddLeftLayer(LayerSyntax layer)
        {
            // TODO: not correct -> implement right behavior
            var clone = this.Clone<ResidualLayerSyntax>();
            clone.PreviousLayer = layer;
            return clone;
        }

        public LayerSyntax AddRightLayer(LayerSyntax layer)
        {
            // TODO: not correct -> implement right behavior
            var clone = this.Clone<ResidualLayerSyntax>();
            clone.PreviousLayer = layer;
            return clone;
        }
    }
}
