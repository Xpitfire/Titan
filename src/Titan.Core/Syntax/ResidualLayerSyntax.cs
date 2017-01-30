using System;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : LayerSyntax
    {
        public ImmutableList<LayerSyntax> LeftBranch { get; internal set; }
        public ImmutableList<LayerSyntax> RightBranch { get; internal set; }

        private ResidualLayerSyntax() : base(SyntaxKind.Residual) { }
        internal ResidualLayerSyntax(
            ImmutableList<LayerSyntax> leftBranch,
            ImmutableList<LayerSyntax> rightBranch) : base(SyntaxKind.Residual)
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

        public override object Clone() => this.Clone<ResidualLayerSyntax>();
    }
}
