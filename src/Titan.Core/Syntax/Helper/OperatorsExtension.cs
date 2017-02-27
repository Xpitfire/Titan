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
        public static ImmutableList<LayerSyntax> Add(this LayerSyntax node1, LayerSyntax node2)
        {
            if (node2 == null) throw new InvalidOperationException($"Null value for parameter {nameof(node2)} not supported!");
            return new[] {node1.DeepClone(), node2}.ToImmutableList();
        }

        public static ImmutableList<LayerSyntax> Append(this LayerSyntax node1, LayerSyntax node2)
        {
            return node1.Add(node2);
        }

        public static ImmutableList<LayerSyntax> Remove(this ImmutableList<LayerSyntax> immutableList, params LayerSyntax[] nodes)
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

        public static ImmutableList<LayerSyntax> Merge(this ImmutableList<LayerSyntax> immutableList1, params ImmutableList<LayerSyntax>[] immutableList2)
        {
            return new ImmutableList<LayerSyntax>(immutableList1, immutableList2);
        }

        public static ImmutableList<LayerSyntax> Merge(this ImmutableList<LayerSyntax> immutableList1, params IList<LayerSyntax>[] immutableList2)
        {
            return new ImmutableList<LayerSyntax>(immutableList1, immutableList2);
        }

        public static InceptionLayerSyntax InceptionBranch(this SyntaxNode root, string name, params SyntaxNode[] nodes)
        {
            return new InceptionLayerSyntax(name, root, nodes);
        }

        public static ResidualLayerSyntax ResidualBranch(this SyntaxNode parent, string name, SyntaxNode left, SyntaxNode right)
        {
            return new ResidualLayerSyntax(name, parent, left, right);
        }
        
    }
}
