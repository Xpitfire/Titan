using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        internal OutputLayerSyntax() : this(null) { }
        public OutputLayerSyntax(string input, string name = null) : base(SyntaxKind.Softmax, input, name) { }
    }
}
