using System;
using HeuristicLab.Common;
using HeuristicLab.Core;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Optimization;
using HeuristicLab.Data;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;
using HeuristicLab.Parameters;
using Titan.HeuristicLab.Problem.Symbol;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    public sealed class Problem : SingleObjectiveBasicProblem<SymbolicExpressionTreeEncoding>
    {
        #region parameter names
        private const string LayerDepthParameterName = "LayerDepth";
        private const string BranchDepthParameterName = "BranchDepth";
        private const string MaxTimeStepsParameterName = "MaxTimeSteps";
        private const string NetworkProgramParameterName = "Program";
        //private const string NetworkGrammarParameterName = "Grammar";
        #endregion

        #region parameters
        public IValueParameter<IntValue> LayerDepthParameter
        {
            get
            {
                return (IValueParameter<IntValue>)
                  Parameters[LayerDepthParameterName];
            }
        }
        public IValueParameter<IntValue> BranchDepthParameter
        {
            get
            {
                return (IValueParameter<IntValue>)
                  Parameters[BranchDepthParameterName];
            }
        }
        public IValueParameter<IntValue> MaxTimeStepsParameter
        {
            get
            {
                return (IValueParameter<IntValue>)
                  Parameters[MaxTimeStepsParameterName];
            }
        }
        #endregion

        #region item cloning and persistence
        // persistence
        [StorableConstructor]
        private Problem(bool deserializing) : base(deserializing) { }
        [StorableHook(HookType.AfterDeserialization)]
        private void AfterDeserialization() { }
        // cloning 
        private Problem(Problem original, Cloner cloner) : base(original, cloner) { }

        public override IDeepCloneable Clone(Cloner cloner)
        {
            return new Problem(this, cloner);
        }
        #endregion

        public Problem() : base()
        {
            Parameters.Add(
                new ValueParameter<IntValue>(
                    LayerDepthParameterName, "Depth of the layers.", new IntValue(20)));
            Parameters.Add(
                new ValueParameter<IntValue>(
                    BranchDepthParameterName, "Depth of the branches.", new IntValue(10)));
            Parameters.Add(
                new ValueParameter<IntValue>(
                    NetworkProgramParameterName, "Number of iterations the network can evolve.", new IntValue(1000)));
            Encoding = new SymbolicExpressionTreeEncoding(
                new TitanGrammar(),
                LayerDepthParameter.Value.Value,
                BranchDepthParameter.Value.Value);
        }

        public override double Evaluate(Individual individual, IRandom random)
        {
            var tree = individual.SymbolicExpressionTree(NetworkProgramParameterName);
            var interpreter = new Interpreter(tree, MaxTimeStepsParameter.Value.Value);
            interpreter.Evaluate();
            return interpreter.Score;
        }

        public override bool Maximization => true;

    }
}
