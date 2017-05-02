using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Traversal;

namespace Titan.Test
{
    [TestClass]
    public class TraversalTest
    {

        [TestMethod]
        public void TestTraversal()
        {
            var traverser = new Traverser();
            traverser.Traverse();
        }

    }
}
