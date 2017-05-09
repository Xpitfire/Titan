using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Database;

namespace Titan.Core.Graph.Traversal
{
    public abstract class Traverser
    {
        public void QueryFullTraversal()
        {
            ConnectionPool.Instance.Execute(session =>
            {
                var result = session.Run("MATCH found = (n:Input)-[:forward*..]->(m:Softmax) RETURN found");
                var enumerator = result.GetEnumerator();
                var network = default(Network);
                if (enumerator.MoveNext())
                {
                    network = NetworkBuilder.Restore(
                        enumerator.Current.Values.Select(v => v.Value as IPath).FirstOrDefault());
                    TraverseResponse(network);
                }
            });
        }

        public abstract void TraverseResponse(Network network);

    }
}
