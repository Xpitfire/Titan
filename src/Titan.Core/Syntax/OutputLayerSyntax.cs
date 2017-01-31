using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : SyntaxNode
    {
        internal OutputLayerSyntax() : this(null) { }
        public OutputLayerSyntax(string name = null) : base(name) { }
        
    }
}
