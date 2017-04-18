using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.HeuristicLab.Problem.Symbol;

namespace Titan.HeuristicLab.Problem
{
    public class Interpreter
    {
        public int MaxTimeSteps { get; private set; }
        public ISymbolicExpressionTree Expression { get; private set; }
        public double Score => currentScore;

        private double currentScore;
        private int currentTimeSteps;

        public Interpreter(ISymbolicExpressionTree tree, int maxTimeSteps)
        {
            this.Expression = tree;
            this.MaxTimeSteps = maxTimeSteps;
            this.currentScore = 0.0;
            this.currentTimeSteps = 0;
        }

        public void Evaluate()
        {
            // start program execution at the root node
            EvaluateNetworkProgram(Expression.Root);
        }

        // evaluate a whole tree branch, each branch returns an integer vector
        private void EvaluateNetworkProgram(
            ISymbolicExpressionTreeNode node)
        {
            // The program-root and start symbols are predefined symbols 
            // in each problem using the symbolic expression tree encoding.
            // These symbols must be handled by the interpreter. Here simply
            // evaluate the whole sub-tree 
            if (node.Symbol is ProgramRootSymbol)
            {
                EvaluateNetworkProgram(node.GetSubtree(0));
            }
            else if (node.Symbol is StartSymbol)
            {
                EvaluateNetworkProgram(node.GetSubtree(0));
            }
            else if (node.Symbol is ConvolutionalLayerSymbol)
            {
                // TODO
                currentScore += 1;
            }
            else if (node.Symbol is FullyConnectedLayerSymbol)
            {
                // TODO
                currentScore += 0.5;
            }
            else if (node.Symbol is InceptionLayerSymbol)
            {
                // TODO
                currentScore += 5;
            }
            else if (node.Symbol is ResNetLayerSymbol)
            {
                // TODO
            }
            else if (node.Symbol is PoolingLayerSymbol)
            {
                // TODO
                currentScore += 2;
            }
            else
            {
                throw
                  new ArgumentException("Invalid symbol in the network program.");
            }

            currentTimeSteps++;
        }
    }
}
