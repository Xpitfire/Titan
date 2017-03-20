using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public class NetworkBuilder : GraphBuilderBase
    {
        private readonly string _name;
        private readonly NetworkParameter _parameter;
        public NetworkBuilder(string name, NetworkParameter parameter = null) : base()
        {
            _name = name;
            _parameter = parameter ?? NetworkParameter.DefaultNetworkParameter;
        }
        
        public LayerBuilder AddInputLayer(InputLayerVertex layer)
        {
            base.AddVertex(layer);
            base.PreviousId = layer.Identifier;
            return new LayerBuilder(this);
        }

        public Network Build()
        {
            return new Network{
                Name = _name,
                Parameter = _parameter,
                Graph = base.Graph.ToArrayAdjacencyGraph()
            };
        }
                
    }
    
}
