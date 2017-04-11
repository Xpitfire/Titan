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
    public sealed class Problem : SingleObjectiveBasicProblem<SymbolicExpressionTreeEncoding>
    {
        #region parameter names
        private const string LayerDepthParameterName = "LayerDepth";
        private const string BranchDepthParameterName = "BranchDepth";
        private const string NetworkProgramParameterName = "Program";
        private const string NetworkGrammarParameterName = "Grammar";
        #endregion

        #region parameters
        public IFixedValueParameter<IntValue> LayerDepthParameter
        {
            get
            {
                return (IFixedValueParameter<IntValue>)
                  Parameters[LayerDepthParameterName];
            }
        }
        public IFixedValueParameter<IntValue> BranchDepthParameter
        {
            get
            {
                return (IFixedValueParameter<IntValue>)
                  Parameters[BranchDepthParameterName];
            }
        }
        public IValueParameter<TitanGrammar> GrammarParameter
        {
            get
            {
                return (IValueParameter<TitanGrammar>)
                  Parameters[NetworkGrammarParameterName];
            }
        }
        #endregion

        [StorableConstructor]
        private Problem(bool deserializing) : base(deserializing)
        {
        }

        private Problem(Problem original, Cloner cloner) : base(original, cloner)
        {
        }

        public Problem() : base()
        {
            Parameters.Add(
                new FixedValueParameter<IntValue>(
                    LayerDepthParameterName, "Depth of the layers.", new IntValue(8)));
            Parameters.Add(
                new FixedValueParameter<IntValue>(
                    BranchDepthParameterName, "Depth of the branches.", new IntValue(8)));
            Encoding = new SymbolicExpressionTreeEncoding(new TitanGrammar());
        }

        public override IDeepCloneable Clone(Cloner cloner) => new Problem(this, cloner);

        public override double Evaluate(Individual individual, IRandom random)
        {
            var tree = individual.SymbolicExpressionTree(NetworkProgramParameterName);
            var quality = EvaluateNetworkProgram(
                LayerDepthParameter.Value.Value, 
                BranchDepthParameter.Value.Value, tree);
            return quality;
        }
        
        public override bool Maximization => true;

        public static double EvaluateNetworkProgram(int layerDepth, int branchDepth,
            ISymbolicExpressionTree tree)
        {
            var score = 0.0;

            // start program execution at the root node
            EvaluateNetworkProgram(tree.Root, layerDepth, branchDepth, ref score);

            return score;
        }

        // evaluate a whole tree branch, each branch returns an integer vector
        private static void EvaluateNetworkProgram(
            ISymbolicExpressionTreeNode node,
            int layerDepth, int branchDepth,
            ref double score)
        {
            // The program-root and start symbols are predefined symbols 
            // in each problem using the symbolic expression tree encoding.
            // These symbols must be handled by the interpreter. Here simply
            // evaluate the whole sub-tree 
            if (node.Symbol is ProgramRootSymbol)
            {
                EvaluateNetworkProgram(node.GetSubtree(0),
                    layerDepth, branchDepth, ref score);
            }
            else if (node.Symbol is StartSymbol)
            {
                EvaluateNetworkProgram(node.GetSubtree(0),
                    layerDepth, branchDepth, ref score);
            }
            else if (node.Symbol is ConvolutionalLayerSymbol)
            {
                // TODO
                score += 1;
            }
            else if (node.Symbol is FullyConnectedLayerSymbol)
            {
                // TODO
                score += 0.5;
            }
            else if (node.Symbol is InceptionLayerSymbol)
            {
                // TODO
                score += 5;
            }
            else if (node.Symbol is ResNetLayerSymbol)
            {
                // TODO
            }
            else if (node.Symbol is PoolingLayerSymbol)
            {
                // TODO
                score += 2;
            }
            else
            {
                throw
                  new ArgumentException("Invalid symbol in the network program.");
            }
        }
    }
}
