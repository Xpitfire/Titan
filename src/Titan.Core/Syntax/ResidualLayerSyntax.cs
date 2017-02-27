using System;
using System.Collections.Generic;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : SyntaxNode
    {
        public SyntaxNode InputLayer { get; internal set; }
        public SyntaxNode LeftBranchOutput { get; internal set; }
        public SyntaxNode RightBranchOutput { get; internal set; }

        private ResidualLayerSyntax() : base() { }
        internal ResidualLayerSyntax(string name,
            SyntaxNode inputLayer,
            SyntaxNode leftBranchOutput,
            SyntaxNode rightBranchOutput) : base(name)
        {
            InputLayer = inputLayer;
            LeftBranchOutput = leftBranchOutput;
            RightBranchOutput = rightBranchOutput;
        }

        public override void Traverse()
        {
            base.Traverse();
            LeftBranchOutput?.Traverse();
            RightBranchOutput?.Traverse();
        }
    }
}
