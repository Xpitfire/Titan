using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax.Type
{
    [Serializable]
    public sealed class PoolingLayerSyntax : LayerSyntax
    {
        internal PoolingLayerSyntax() : base(SyntaxKind.Pooling)
        {
        }

    }
}
