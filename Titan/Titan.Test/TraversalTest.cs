using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Traversal;
using Titan.Core.Graph;
using System.Diagnostics;

namespace Titan.Test
{
    [TestClass]
    public class TraversalTest
    {
        public class TestTraverser : Traverser
        {
            public override void TraverseResponse(Network network)
            {
                if (network == null) throw new ArgumentNullException();
                Debug.Print("Vertices: ");
                foreach (var vertex in network.Vertices)
                {
                    Debug.Print("Vertex {");
                    Debug.Print(vertex.Name);
                    Debug.Print(vertex.Kind.ToString());
                    Debug.Print("}");
                }
                Debug.Print("References: ");
                foreach (var reference in network.References)
                {
                    Debug.Print("Entrie {");
                    Debug.Print(reference.Node1);
                    Debug.Print(reference.Node2);
                    Debug.Print("}");
                }
            }
        }

        [TestMethod]
        public void TestTraversal()
        {
            var traverser = new TestTraverser();
            traverser.QueryFullTraversal();
        }

    }
}
