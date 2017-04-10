using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class FullyConnectedLayerSymbol : Symbol
    {
        private FullyConnectedLayerSymbol(FullyConnectedLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public FullyConnectedLayerSymbol() : base("FullyConnectedSymbol", "Creates a fully connected layer on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new FullyConnectedLayerSymbol(this, cloner);
        }

        public override int MinimumArity => 1;
        public override int MaximumArity => 1;
    }
}