using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        internal OutputLayerSyntax() : base(SyntaxKind.Output)
        {
        }
        
        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<OutputLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }
}
