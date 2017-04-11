using HeuristicLab.Common;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem.Symbol
{
    [StorableClass]
    public class FullyConnectedLayerSymbol : global::HeuristicLab.Encodings.SymbolicExpressionTreeEncoding.Symbol
    {
        [StorableConstructor]
        private FullyConnectedLayerSymbol(bool deserializing) : base(deserializing)
        {
        }

        private FullyConnectedLayerSymbol(FullyConnectedLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public FullyConnectedLayerSymbol() : base(nameof(FullyConnectedLayerSymbol), "Creates a fully connected layer on the previous output neurons.")
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