using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class SoftmaxSymbol : Symbol
    {
        private SoftmaxSymbol(SoftmaxSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public SoftmaxSymbol() : base("SoftmaxSymbol", "Creates a end softmax layer on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new SoftmaxSymbol(this, cloner);
        }

        public override int MinimumArity => 1;
        public override int MaximumArity => 1;
    }
}