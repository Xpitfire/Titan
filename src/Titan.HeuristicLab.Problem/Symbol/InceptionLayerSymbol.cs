using HeuristicLab.Common;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public class InceptionLayerSymbol : Symbol
    {
        private InceptionLayerSymbol(InceptionLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public InceptionLayerSymbol() : base("InceptionLayerSymbol", "Creates a multi-branch layer on the previous output neurons.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new InceptionLayerSymbol(this, cloner);
        }

        public override int MinimumArity => 2;
        public override int MaximumArity => 5;
    }
}