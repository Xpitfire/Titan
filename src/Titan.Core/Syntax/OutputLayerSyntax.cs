using System;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        private OutputLayerSyntax() : this(null) { }

        internal OutputLayerSyntax(string name) : base(SyntaxKind.Softmax, name)
        {
        }
    }
}
