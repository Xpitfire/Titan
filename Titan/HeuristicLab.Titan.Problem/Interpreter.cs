using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Builder;
using Titan.HeuristicLab.Problem.Symbol;

namespace Titan.HeuristicLab.Problem
{
    public class Interpreter
    {
        public NetworkBuilder NetworkBuilder { get; private set; }
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
            // create new network builder
            NetworkBuilder = new NetworkBuilder("test5");
            // start program execution at the root node
            EvaluateNetworkProgram(Expression.Root, NetworkBuilder);
        }

        /// Evaluate a whole tree branch, each branch returns an integer vector.
        /// Evaluation algorithm-> transform tree to graph
        /// 1. Recursive decention within node
        ///      - if current node is a end node then return
        ///      - else if current node is regular node then add the type to the builder
        ///        and if node has futher nodes create new builder for branches
        /// 2. Use the NetworkBuilder to transform into vertices and relashionships
        /// 3. Send result via Rest API to external Evaluation Endpoint
        /// 4. Return final result
        private void EvaluateNetworkProgram(ISymbolicExpressionTreeNode node, GraphBuilderBase builder)
        {
            // The program-root and start symbols are predefined symbols 
            // in each problem using the symbolic expression tree encoding.
            // These symbols must be handled by the interpreter. Here simply
            // evaluate the whole sub-tree 
            if (node.Symbol is ProgramRootSymbol)
            {
                EvaluateNetworkProgram(node.GetSubtree(0), builder);
            }
            else if (node.Symbol is StartSymbol)
            {
                EvaluateNetworkProgram(node.GetSubtree(0), builder);
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
            else if (node.Symbol is PoolingLayerSymbol)
            {
                // TODO
                currentScore += 2;
            }

            currentTimeSteps++;
        }



    }
}
