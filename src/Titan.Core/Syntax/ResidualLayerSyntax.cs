using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax.Type
{
    [Serializable]
    public sealed class ResidualLayerSyntax : LayerSyntax
    {
        public ImmutableArray<LayerSyntax> Layers { get; }

        internal ResidualLayerSyntax() : base(SyntaxKind.Residual) { }
        internal ResidualLayerSyntax(ImmutableArray<LayerSyntax> layers) : base(SyntaxKind.Residual)
        {
            Layers = layers;
        }
        
    }
}
