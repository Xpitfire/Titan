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
            return null;
        }
    }
}
