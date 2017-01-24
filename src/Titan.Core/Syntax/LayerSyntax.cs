using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public abstract class LayerSyntax : SyntaxNode
    {
        public static event VisitorDelegate<LayerSyntax> VisitedEvent;

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
        public LayerSyntax NextLayer { get; internal set; }
        
        protected LayerSyntax(SyntaxKind kind, string name = null)
        {
            Kind = kind;
            Name = name;
        }

        public abstract LayerSyntax AddNextLayer(LayerSyntax layer);

        internal override void Traverse() => VisitedEvent?.Invoke(this);
    }
}
