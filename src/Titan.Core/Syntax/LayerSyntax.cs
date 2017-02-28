using System;
using System.Linq;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public abstract class LayerSyntax : SyntaxNode
    {
        [Serializable]
        public enum SyntaxKind
        {
            Convolutional,
            Pooling,
            Scaling,
            BatchNormalization,
            FullyConnected,
            Softmax
        }
        
        public SyntaxKind Kind { get; internal set; }
        
        protected LayerSyntax(SyntaxKind kind, string name) : base(name)
        {
            Kind = kind;
        }
    }
}
