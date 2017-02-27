using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class MergeLayerSyntax : SyntaxNode
    {
        public ImmutableList<SyntaxNode> InputLayers { get; internal set; }
        public SyntaxNode OutputLayer { get; internal set; }

        private MergeLayerSyntax() { }

        internal MergeLayerSyntax(string name, SyntaxNode outputLayer, InceptionLayerSyntax inceptionLayer) : base(name)
        {
            OutputLayer = outputLayer;
            InputLayers = inceptionLayer.LeafLayers;
        }

        public MergeLayerSyntax(string name, SyntaxNode outputLayer, ResidualLayerSyntax residualLayer) : base(name)
        {
            OutputLayer = outputLayer;
            InputLayers = new ImmutableList<SyntaxNode>(residualLayer.LeftLeafLayer, residualLayer.RightLeafLayer);
        }
    }
}
