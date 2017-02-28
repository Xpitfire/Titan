using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax.Visitor
{
    [Serializable]
    internal class Vertex
    {
        internal bool Visited { get; set; }
        internal int Distance { get; set; }
        internal SyntaxNode Root { get; set; }

        private Vertex() { }
        internal Vertex(SyntaxNode node)
        {
            Root = node;
        }

        public static implicit operator SyntaxNode(Vertex node)
        {
            return node.Root;
        }

        public static implicit operator Vertex(SyntaxNode node)
        {
            return new Vertex(node);
        }
    }
}
