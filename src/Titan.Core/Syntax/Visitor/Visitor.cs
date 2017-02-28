using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax.Visitor
{
    [Serializable]
    public class Visitor
    {
        public static void TraverseDepthFirst(NetworkSyntax network)
        {
            
        }

        public static void TraverseBreadthFirst(NetworkSyntax network)
        {
            var frontier = new Stack<Vertex>();
            Vertex root = network;
            root.Distance = 0;
            root.Visited = true;
            frontier.Push(root);
            while (frontier.Count > 0)
            {
                var cur = frontier.Pop();
                foreach (Vertex suc in Successor(cur))
                {
                    if (suc.Visited) continue;
                    frontier.Push(suc);
                    suc.Visited = true;
                    suc.Distance += 1;
                }
            }
        }

        private static IEnumerable Successor(Vertex vertex)
        {
            var network = vertex.Root as NetworkSyntax;
            if (network != null)
            {
                foreach (var inputLayer in network.Layers)
                {
                    yield return inputLayer;
                }
            }

            var layer = vertex.Root as LayerSyntax;
            if (layer != null)
            {
                yield return layer.OutputLayer;
            }

            var inceptionLayer = vertex.Root as InceptionLayerSyntax;
            if (inceptionLayer != null)
            {
                foreach (var outputLayer in inceptionLayer.OutputLayers)
                {
                    yield return outputLayer;
                }
            }

            var residualLayer = vertex.Root as ResidualLayerSyntax;
            if (residualLayer != null)
            {
                yield return residualLayer.LeftBranchOutputLayer;
                yield return residualLayer.RightBranchOutputLayer;
            }

            var mergeLayer = vertex.Root as MergeLayerSyntax;
            if (mergeLayer != null)
            {
                yield return mergeLayer.OutputLayer;
            }
        }
    }
}
