using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public abstract class GraphBuilderBase : IGraphBuilder<LayerVertex>
    {
        internal AdjacencyGraph<LayerVertex, Edge<LayerVertex>> Graph { get; set; }
        internal Identifier PreviousId { get; set; }


        protected GraphBuilderBase() : this(new AdjacencyGraph<LayerVertex, Edge<LayerVertex>>()) { }
        protected GraphBuilderBase(AdjacencyGraph<LayerVertex, Edge<LayerVertex>> graph)
        {
            Graph = graph;
        }

        public ArrayAdjacencyGraph<LayerVertex, Edge<LayerVertex>> BuildGraph()
        {
            return Graph.ToArrayAdjacencyGraph();
        }

        protected void AddVertex(LayerVertex vertex)
        {
            if (vertex == null) return;
            Graph.AddVertex(vertex);
        }

        protected void AddVertices(LayerVertex[] paramLayers)
        {
            foreach (var layerVertex in paramLayers)
            {
                if (layerVertex == null) continue;
                Graph.AddVertex(layerVertex);
            }
        }

        protected void AddEdge(Identifier vertexId1, Identifier vertexId2, bool cycle = false) => AddEdge(vertexId1.Id, vertexId2.Id, cycle);
        protected void AddEdge(string vertexId1, string vertexId2, bool cycle = false)
        {
            var vertex1 = Graph.Vertices.First(v => v.Identifier.Id == vertexId1);
            var vertex2 = Graph.Vertices.FirstOrDefault(v => v.Identifier.Id == vertexId2);
            if (vertex1 == null)
                throw new ArgumentException($"Could not find defined vertex ID: {vertexId1}");
            if (vertex2 == null)
                throw new ArgumentException($"Could not find defined vertex ID: {vertexId2}");
            Graph.AddEdge(new Edge<LayerVertex>(vertex1, vertex2));
            if (cycle)
                Graph.AddEdge(new Edge<LayerVertex>(vertex2, vertex1));
        }
    }
}
