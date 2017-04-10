using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class ConvolutionalLayerSymbol : Symbol
    {
        private ConvolutionalLayerSymbol(ConvolutionalLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public ConvolutionalLayerSymbol() : base("ConvolutionalLayerSymbol", "Creates a convolution on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new ConvolutionalLayerSymbol(this, cloner);
        }

        public override int MinimumArity => 1;
        public override int MaximumArity => 1;
    }
}
