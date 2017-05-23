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
    public sealed class Problem : SymbolicExpressionTreeProblem
    {
        #region parameter names
        private const string LayerDepthParameterName = "LayerDepth";
        private const string BranchDepthParameterName = "BranchDepth";
        private const string MaxTimeStepsParameterName = "MaxTimeSteps";
        private const string NetworkProgramParameterName = "Program";
        #endregion

        #region parameters
        public IValueParameter<IntValue> MinimumLength
        {
            get
            {
                return (IValueParameter<IntValue>)
                  Parameters[LayerDepthParameterName];
            }
        }
        public IValueParameter<IntValue> MaximumDepth
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
        public Problem(bool deserializing) : base(deserializing) { }
        [StorableHook(HookType.AfterDeserialization)]
        public void AfterDeserialization() { }
        // cloning 
        public Problem(Problem original, Cloner cloner) : base(original, cloner) { }

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
                    MaxTimeStepsParameterName, "Ammount of repetitions.", new IntValue(3)));
            Parameters.Add(
                new ValueParameter<IntValue>(
                    BranchDepthParameterName, "Depth of the branches.", new IntValue(10)));
            Parameters.Add(
                new ValueParameter<IntValue>(
                    NetworkProgramParameterName, "Number of iterations the network can evolve.", new IntValue(1000)));
            Encoding = new SymbolicExpressionTreeEncoding(
                new TitanGrammar());
        }
        
        public override double Evaluate(ISymbolicExpressionTree tree, IRandom random)
        {
            var interpreter = new Interpreter(tree, MaxTimeStepsParameter.Value.Value);
            interpreter.Evaluate();
            return interpreter.Score;
        }

        public override bool Maximization => true;

    }
}
