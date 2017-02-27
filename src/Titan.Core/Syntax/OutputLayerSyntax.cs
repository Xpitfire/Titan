using System;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        public ImmutableList<SyntaxNode> InputLayers { get; internal set; }

        private OutputLayerSyntax() : this(null) { }

        internal OutputLayerSyntax(string name, ImmutableList<SyntaxNode> inputLayers = null) : base(SyntaxKind.Softmax, name)
        {
            InputLayers = inputLayers;
        }

        public OutputLayerSyntax AddInputs(ImmutableList<SyntaxNode> inputLayers)
        {
            var clone = this.DeepClone();
            clone.InputLayers = inputLayers;
            return clone;
        } 
    }
}
