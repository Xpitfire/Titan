using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax.Type
{
    [Serializable]
    public abstract class LayerSyntax : SyntaxNode
    {
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

        internal LayerSyntax(SyntaxKind kind)
        {
            Kind = kind;
        }

    }
}
