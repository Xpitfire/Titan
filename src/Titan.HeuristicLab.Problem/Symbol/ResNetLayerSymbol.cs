using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class ResNetLayerSymbol : Symbol
    {
        private ResNetLayerSymbol(ResNetLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public ResNetLayerSymbol() : base("ResNetLayerSymbol", "Creates a residual-branch layer on the previous output neurons.")
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