using HeuristicLab.Common;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem.Symbol
{
    [StorableClass]
    public class ResNetLayerSymbol : global::HeuristicLab.Encodings.SymbolicExpressionTreeEncoding.Symbol
    {
        [StorableConstructor]
        private ResNetLayerSymbol(ResNetLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public ResNetLayerSymbol() : base(nameof(ResNetLayerSymbol), "Creates a residual-branch layer on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new ResNetLayerSymbol(this, cloner);
        }

        public override int MinimumArity => 2;
        public override int MaximumArity => 2;
    }
}