using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ScaleLayerSyntax : LayerSyntax
    {
        public bool BiasTerm { get; internal set; }

        private ScaleLayerSyntax() : this(null) { }
        internal ScaleLayerSyntax(string name, bool biasTerm = true) : base(SyntaxKind.Scaling, name)
        {
            BiasTerm = biasTerm;
        }
    }
}
