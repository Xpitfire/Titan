using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class FullyConnectedSymbol : Symbol
    {
        private FullyConnectedSymbol(FullyConnectedSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public FullyConnectedSymbol() : base("FullyConnectedSymbol", "Creates a fully connected layer on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new FullyConnectedSymbol(this, cloner);
        }

        public override int MinimumArity => 1;
        public override int MaximumArity => 1;
    }
}