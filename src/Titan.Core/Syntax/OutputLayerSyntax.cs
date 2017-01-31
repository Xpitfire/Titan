using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        internal OutputLayerSyntax() : this(null) { }
        public OutputLayerSyntax(string name = null) : base(SyntaxKind.Output, name) { }
        
    }
}
