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
            Residual,
            Inception,  
            Softmax
        }

        public string Input { get; internal set; }
        public SyntaxKind Kind { get; internal set; }
        
        protected LayerSyntax(SyntaxKind kind, string input, string name = null) : base(name)
        {
            Input = input;
            Kind = kind;
        }

        internal virtual LayerSyntax FindLayerByIdentifier(Identifier id)
            => (id == null) ? null : FindLayerByName(id.Id);
        internal virtual LayerSyntax FindLayerByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            return (Identifier.Id == name) ? this : null;
        }

    }
}
