using System;

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
            Residual,
            Inception,
            Softmax,
            Input,
            Output
        }

        public SyntaxKind Kind { get; internal set; }

        protected LayerSyntax(SyntaxKind kind)
        {
            Kind = kind;
        }
        
    }
}
