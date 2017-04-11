﻿using HeuristicLab.Common;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem.Symbol
{
    [StorableClass]
    public class InceptionLayerSymbol : global::HeuristicLab.Encodings.SymbolicExpressionTreeEncoding.Symbol
    {
        [StorableConstructor]
        private InceptionLayerSymbol(bool deserializing) : base(deserializing)
        {
        }

        private InceptionLayerSymbol(InceptionLayerSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public InceptionLayerSymbol() : base(nameof(InceptionLayerSymbol), "Creates a multi-branch layer on the previous output neurons.")
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