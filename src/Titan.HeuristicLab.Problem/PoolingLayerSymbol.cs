using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class PoolingLayerSymbol : Symbol
    {
        [StorableConstructor]
        private PoolingLayerSymbol(bool deserializing) : base(deserializing)
        {
        }

        private PoolingLayerSymbol(PoolingLayerSymbol original, Cloner cloner) : base(original, cloner)
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