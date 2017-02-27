using System;
using System.Collections.Generic;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : SyntaxNode
    {
        public SyntaxNode InputLayer { get; internal set; }
        public SyntaxNode LeftBranchOutputLayer { get; internal set; }
        public SyntaxNode RightBranchOutputLayer { get; internal set; }
        public SyntaxNode LeftLeafLayer { get; internal set; }
        public SyntaxNode RightLeafLayer { get; internal set; }

        private ResidualLayerSyntax() : base() { }
        internal ResidualLayerSyntax(string name,
            SyntaxNode inputLayer,
            SyntaxNode leftBranchOutputLayer,
            SyntaxNode rightBranchOutputLayer) : base(name)
        {
            InputLayer = inputLayer;
            LeftBranchOutputLayer = leftBranchOutputLayer;
            RightBranchOutputLayer = rightBranchOutputLayer;
            LeftLeafLayer = LeftBranchOutputLayer;
            RightLeafLayer = RightBranchOutputLayer;
        }

        public override void Traverse()
        {
            base.Traverse();
            LeftBranchOutputLayer?.Traverse();
            RightBranchOutputLayer?.Traverse();
        }
    }
}
