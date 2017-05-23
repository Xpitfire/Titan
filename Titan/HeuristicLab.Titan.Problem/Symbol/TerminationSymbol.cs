using HeuristicLab.Common;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicLab.Titan.Problem.Symbol
{
    [StorableClass]
    public class TerminationSymbol : global::HeuristicLab.Encodings.SymbolicExpressionTreeEncoding.Symbol
    {
        [StorableConstructor]
        public TerminationSymbol(TerminationSymbol original, Cloner cloner) : base(original, cloner)
        {
        }

        public TerminationSymbol() : base(nameof(TerminationSymbol), "Creates a termination for a branch.")
        {
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new TerminationSymbol(this, cloner);
        }

        public override int MinimumArity => 0;
        public override int MaximumArity => 0;
    }
}
