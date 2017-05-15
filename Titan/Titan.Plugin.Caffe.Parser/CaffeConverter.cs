using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph;
using Titan.Core.Graph.Builder;
using Titan.Core.Graph.Vertex;
using static Titan.Core.Graph.Vertex.VertexFactory;

namespace Titan.Plugin.Caffe.Parser
{
    internal class CaffeConverter
    {
        public Dictionary<string, dynamic> Properties { get; }
        public Network Network { get; private set; }

        public CaffeConverter(Dictionary<string, dynamic> properties)
        {
            this.Properties = properties;
        }

        public void TransformToNetwork()
        {
            // This code conforms to the current proto2 Caffe Specification from
            // GitHub: https://github.com/BVLC/caffe/blob/master/src/caffe/proto/caffe.proto
            var networkBuilder = new NetworkBuilder(Properties["name"]);

            // TODO Extend to entire functionality:
            // TODO handle dimensions
            //foreach (var shape in Properties["input_shape"]["dim"])
            //{
            //}

            var relashinships = new List<Relationship>();

            // TODO handle multiple input layer
            var layers = FromLayers()
                .Select(l => (LayerVertex)Convert(l));
            
            Network = NetworkBuilder.Restore(layers.ToList(), relashinships);
        }

        private LayerVertex Convert(dynamic layer)
        {
            string name = layer["name"];
            switch (layer["type"])
            {
                case "Data":
                    return InputLayer(name);

                case "Convolution":
                    return ConvLayer(name, null);

                default:
                    // TODO checkk all types and throw exception if no type match
                    //throw new InvalidOperationException("Unklnown layer type!");
                    return null;
            }
        }
        
        public List<dynamic> FromLayers()
        {
            return (List<dynamic>)Properties["layer"];
        }
        
    }
    
}
