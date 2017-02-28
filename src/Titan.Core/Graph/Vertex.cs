using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;
using Titan.Core.Graph;

namespace Titan.Core.Syntax.Visitor
{
    [Serializable]
    public sealed class Vertex<T> where T : SyntaxNode
    {
        internal bool Visited { get; set; }
        internal int Distance { get; set; }
        public T Node { get; internal set; }
        
        private Vertex() { }
        internal Vertex(T node)
        {
            Node = node;
        }

        public static implicit operator Vertex<T>(T node)
        {
            return new Vertex<T>(node);
        }

        public static implicit operator T(Vertex<T> vertex)
        {
            return vertex.Node;
        }
    }
}
