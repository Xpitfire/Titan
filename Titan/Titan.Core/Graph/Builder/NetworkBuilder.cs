using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;
using Neo4j.Driver.V1;
using Titan.Core.Collection;

namespace Titan.Core.Graph.Builder
{
    public class NetworkBuilder : GraphBuilderBase
    {

        public NetworkBuilder(string name) : base(name)
        {
        }

        public LayerBuilder AddInputLayer(InputLayerVertex layer)
        {
            base.AddVertex(layer);
            base.PreviousId = layer.Identifier;
            return new LayerBuilder(this);
        }
        
        public Network Build()
        {
            return new Network {
                Name = Graph.GraphId.Id,
                Vertices = Vertices.Select(v => v.Value as LayerVertex).ToImmutableList(),
                References = Relationships.ToImmutableList()
            };
        }

        public static Network Restore(IList<LayerVertex> vertices, IList<Relationship> relashionships)
        {
            return new Network
            {
                Name = new Identifier().Id,
                Vertices = vertices.ToImmutableList(),
                References = relashionships.ToImmutableList()
            };
        }

        public static Network Restore(IPath graphPaths)
        {
            if (graphPaths == null) return null;

            var vertices = graphPaths.Nodes.Select(n => Convert(n))
                .AsParallel().Distinct().ToImmutableList();
            var relashionships = Convert(graphPaths.Relationships, graphPaths.Nodes);

            return new Network
            {
                Name = new Identifier().Id,
                Vertices = vertices,
                References = relashionships,
            };
        }

        private static ImmutableList<Relationship> Convert(IReadOnlyList<IRelationship> relationships, IReadOnlyList<INode> nodes)
        {
            var nodeDict = nodes
                .AsParallel().Distinct().ToDictionary(n => n.Id, n => n);
            var nameProp = nameof(LayerVertex.Name);
            var tempRelations = relationships.Select(
                r => new Relationship(
                    nodeDict[r.StartNodeId].Properties[nameProp].ToString(),
                    nodeDict[r.EndNodeId].Properties[nameProp].ToString(),
                    false
                )).ToList();
            return tempRelations
                .ResolveDistinctCycles()
                .ToImmutableList();
        }

        private static LayerVertex Convert(INode node)
        {
            var layer = default(LayerVertex);
            if (Enum.TryParse(node.Properties[nameof(LayerVertex.Kind)].ToString(), out VertexKind kind))
            {
                switch (kind)
                {
                    case VertexKind.Input:
                        layer = new InputLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Convolutional:
                        layer = new ConvolutionalLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Pooling:
                        layer = new PoolingLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Scaling:
                        layer = new ScaleLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Dropout:
                        layer = new DropoutLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.BatchNormalization:
                        layer = new BatchNormalizationLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Activation:
                        layer = new ActivationLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Eltwise:
                        layer = new EltwiseLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Concat:
                        layer = new ConcatLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.FullyConnected:
                        layer = new FullyConnectedLayerVertex().Deserialize(node.Properties);
                        break;
                    case VertexKind.Softmax:
                        layer = new SoftmaxLayerVertex().Deserialize(node.Properties);
                        break;
                    default:
                        break;
                }
            }
            return layer;
        }

    }
    
}
