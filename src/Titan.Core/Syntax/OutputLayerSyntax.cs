using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        internal OutputLayerSyntax() : base(SyntaxKind.Output)
        {
        }

        public override object Clone() => this.Clone<OutputLayerSyntax>();
    }
}
