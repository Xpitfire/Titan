using HeuristicLab.Common;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem.Symbol
{
    [StorableClass]
    public class ConvolutionalLayerSymbol : global::HeuristicLab.Encodings.SymbolicExpressionTreeEncoding.Symbol
    {
        [StorableConstructor]
        public ConvolutionalLayerSymbol(bool deserializing) : base(deserializing)
        {
        }

        public ConvolutionalLayerSymbol(ConvolutionalLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public ConvolutionalLayerSymbol() : base(nameof(ConvolutionalLayerSymbol), "Creates a convolution on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new ConvolutionalLayerSymbol(this, cloner);
        }

        public override int MinimumArity => 1;
        public override int MaximumArity => 5;
    }
}
