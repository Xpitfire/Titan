using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax.Type
{
    [Serializable]
    public sealed class OutputLayerSyntax : LayerSyntax
    {
        internal OutputLayerSyntax() : base(SyntaxKind.Output)
        {
        }
    }
}
