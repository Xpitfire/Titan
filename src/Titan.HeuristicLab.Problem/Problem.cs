using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeuristicLab.Common;
using HeuristicLab.Core;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Optimization;

namespace Titan.HeuristicLab.Problem
{
    public sealed class Problem : SingleObjectiveBasicProblem<SymbolicExpressionTreeEncoding>
    {
        public const string SymbolicTreeName = "Titan";

        private Problem(Problem original, Cloner cloner) : base(original, cloner) { }
        public Problem() : base()
        {
            var g = new SimpleSymbolicExpressionGrammar();
            g.AddSymbol("conv", 1, 1);
            g.AddSymbol("pool", 1, 1);
            g.AddSymbol("branch", 2, 2);
            g.AddTerminalSymbols(new[] { "1", "2", "3" });
            Encoding = new SymbolicExpressionTreeEncoding(SymbolicTreeName, g, 10, 5);
        }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new Problem(this, cloner);
        }

        public override double Evaluate(Individual individual, IRandom random)
        {
            var t = individual.SymbolicExpressionTree(SymbolicTreeName);
            var quality = 0.0;
            return quality;
        }

        public override bool Maximization => false;
    }
}
