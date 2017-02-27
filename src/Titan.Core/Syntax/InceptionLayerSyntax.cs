using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InceptionLayerSyntax : SyntaxNode
    {
        public SyntaxNode InputLayer { get; internal set; }
        public ImmutableList<SyntaxNode> OutputLayers { get; internal set; }
        public ImmutableList<SyntaxNode> LeafLayers { get; internal set; }

        private InceptionLayerSyntax() : base() { }
        internal InceptionLayerSyntax(string name, SyntaxNode inputLayer, params SyntaxNode[] outputLayers) : base(name)
        {
            InputLayer = inputLayer;
            OutputLayers = outputLayers.ToImmutableList();
            LeafLayers = OutputLayers;
        }
    }
}
