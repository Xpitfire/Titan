using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.Core.Graph.Vertex;
using Titan.Core.Graph.Database;

namespace Titan.Core.Graph.Builder
{
    public abstract class GraphBuilderBase : IGraphBuilder<LayerVertex>
    {
        public IDictionary<string, LayerVertex> Vertices { get; }
        public IList<Tuple<string, string, bool>> References { get; }
        public Identifier GraphId { get; private set; }

        internal GraphBuilderBase Graph { get; set; }
        internal Identifier PreviousId { get; set; }

        private GraphBuilderBase() { }
        protected GraphBuilderBase(string graphId)
        {
            Graph = this;
            GraphId = new Identifier(graphId);
            Vertices = new ConcurrentDictionary<string, LayerVertex>();
            References = new List<Tuple<string, string, bool>>();
        }
        protected GraphBuilderBase(GraphBuilderBase graph)
        {
            Graph = graph;
            GraphId = graph.GraphId;
        }

        public void PersistGraph()
        {
            ConnectionPool.Instance.Execute(session =>
            {
                foreach (var vertex in Graph.Vertices)
                {
                    var props = vertex.Value.Serialize();
                    var labels = props.Keys.ToList();
                    var query = new StringBuilder();
                    for (var i = 0; i < labels.Count; i++)
                    {
                        query.Append($"{labels[i]}: {{{labels[i]}}}");
                        if (i < labels.Count - 1)
                            query.Append(", ");
                    }

                    session.Run($"CREATE (a:{Graph.GraphId.Id} {{{query}}})",
                        vertex.Value.Serialize());
                }
                foreach (var reference in Graph.References)
                {
                    if (reference.Item3) // cycles
                    {
                        session.Run($"MATCH (l1:{Graph.GraphId.Id} {{{nameof(LayerVertex.Name)}: {{name1}}}}), (l2:{Graph.GraphId.Id} {{{nameof(LayerVertex.Name)}: {{name2}}}})" +
                                    "CREATE (l1)-[:forward]->(l2)" +
                                    "CREATE (l2)-[:forward]->(l1)",
                                    new Dictionary<string, object>
                                    {
                                        { "name1", $"{reference.Item1}" },
                                        { "name2", $"{reference.Item2}" }
                                    });
                    }
                    else // directed
                    {
                        session.Run($"MATCH (l1:{Graph.GraphId.Id} {{{nameof(LayerVertex.Name)}: {{name1}}}}), (l2:{Graph.GraphId.Id} {{{nameof(LayerVertex.Name)}: {{name2}}}})" +
                                    "CREATE (l1)-[:forward]->(l2)",
                                    new Dictionary<string, object>
                                    {
                                        { "name1", $"{reference.Item1}" },
                                        { "name2", $"{reference.Item2}" }
                                    });
                    }
                }
            });
        }

        protected void AddVertex(LayerVertex vertex)
        {
            if (vertex == null) return;
            Graph.Vertices[vertex.Identifier.Id] = vertex;
        }

        protected void AddVertices(LayerVertex[] paramLayers)
        {
            foreach (var layerVertex in paramLayers)
            {
                if (layerVertex == null) continue;
                AddVertex(layerVertex);
            }
        }

        protected void AddEdge(Identifier vertexId1, Identifier vertexId2, bool cycle = false)
        {
            var graphRef = new Tuple<string, string, bool>(vertexId1.Id, vertexId2.Id, cycle);
            Graph.References.Add(graphRef);
        }
    }
}
