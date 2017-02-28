using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class BatchNormalizationLayerSyntax : LayerSyntax
    {
        public bool UseGlobalStats { get; internal set; }

        private BatchNormalizationLayerSyntax() : this(null)  { }
        internal BatchNormalizationLayerSyntax(string name, bool useGlobalStats = true) : base(SyntaxKind.BatchNormalization, name)
        {
            UseGlobalStats = useGlobalStats;
        }
    }
}
