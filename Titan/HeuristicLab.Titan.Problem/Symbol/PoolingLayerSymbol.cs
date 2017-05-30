using HeuristicLab.Common;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem.Symbol
{
    [StorableClass]
    public class PoolingLayerSymbol : global::HeuristicLab.Encodings.SymbolicExpressionTreeEncoding.Symbol
    {
        [StorableConstructor]
        protected PoolingLayerSymbol(bool deserializing) : base(deserializing)
        {
        }

        protected PoolingLayerSymbol(PoolingLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public PoolingLayerSymbol() : base(nameof(PoolingLayerSymbol), "Creates a pooling layer on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new PoolingLayerSymbol(this, cloner);
        }

        public override int MinimumArity => 1;
        public override int MaximumArity => 1;
    }
}