using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    public static class OperatorsExtension
    {
        public static ImmutableList<SyntaxNode> Add(this SyntaxNode node1, SyntaxNode node2)
        {
            if (node2 == null) throw new InvalidOperationException($"Null value for parameter {nameof(node2)} not supported!");
            return new[] {node1.DeepClone(), node2}.ToImmutableList();
        }
        
        public static ImmutableList<SyntaxNode> Remove(this ImmutableList<SyntaxNode> immutableList, params SyntaxNode[] nodes)
        {
            var list = immutableList.ToList();
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    list.Remove(node);
                }
            }
            return list.ToImmutableList();
        }

        public static ImmutableList<SyntaxNode> Merge(this ImmutableList<SyntaxNode> immutableList1, params SyntaxNode[] immutableList2)
        {
            return new ImmutableList<SyntaxNode>(immutableList1, immutableList2);
        }

        public static ImmutableList<SyntaxNode> Merge(this ImmutableList<SyntaxNode> immutableList1, params ImmutableList<SyntaxNode>[] immutableList2)
        {
            return new ImmutableList<SyntaxNode>(immutableList1, immutableList2);
        }

        public static ImmutableList<SyntaxNode> Merge(this ImmutableList<SyntaxNode> immutableList1, params IList<SyntaxNode>[] immutableList2)
        {
            return new ImmutableList<SyntaxNode>(immutableList1, immutableList2);
        }
    }
}
