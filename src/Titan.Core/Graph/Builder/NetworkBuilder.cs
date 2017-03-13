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
        private string _name;
        private NetworkParameter _parameter;
        public NetworkBuilder(string name, NetworkParameter parameter = null) : base()
        {
            _name = name;
            _parameter = parameter ?? NetworkParameter.DefaultNetworkParameter;
        }
        
        public LayerBuilder AddInputLayer(InputLayerVertex layer)
        {
            base.AddVertex(layer);
            return new LayerBuilder(this, layer.Identifier);
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
