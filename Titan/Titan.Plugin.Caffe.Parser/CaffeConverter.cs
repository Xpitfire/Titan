using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;
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
                    List<dynamic> decayParamList = Try<List<dynamic>>(layer, "param");
                    ImmutableList<ConvolutionalLayerLearningRateParameter> learnRateParamList = null;
                    if (decayParamList != null)
                    {
                        learnRateParamList = decayParamList.Select(d => 
                        {
                            return (ConvolutionalLayerLearningRateParameter)ConvLayerLearnRateParam(
                                Try<int>(d, "lr_mult"),
                                Try<int>(d, "decay_mult")
                            );
                        }).ToList().ToImmutableList();
                    }

                    var convParamDict = layer["convolution_param"];
                    ConvolutionalLayerParameter convParam = ConvLayerParam(
                        int.Parse(convParamDict["num_output"]),
                        int.Parse(convParamDict["kernel_size"]),
                        Try<int>(convParamDict, "pad", 0),
                        Try<int>(convParamDict, "stride", 1),
                        Try<bool>(convParamDict, "bias_term", false));

                    var weightFillerDict = Try<Dictionary<string, dynamic>>(convParamDict, "weight_filler");
                    
                    return ConvLayer(name, convParam, learnRateParamList);

                case "LRN":
                    var learnDict = layer["lrn_param"];
                    var learnLocalSize = int.Parse(learnDict["local_size"]);
                    var learnAlpha = float.Parse(learnDict["alpha"], CultureInfo.InvariantCulture);
                    var learnBeta = float.Parse(learnDict["beta"], CultureInfo.InvariantCulture);



                    Dictionary<string, dynamic> learnParamDict = Try<Dictionary<string, dynamic>>(layer, "lrn_param");


















                    return LearnLayer(name,
                        learnLocalSize, 
                        learnAlpha, 
                        learnBeta);

                case "ReLu":
                    return ActivationLayer(name, ActivationFunctionType.ReLU);

                case "Pooling":
                    var poolParamDict = layer["pooling_param"];
                    string poolType = poolParamDict["pool"];
                    int poolKernelSize = int.Parse(poolParamDict["kernel_size"]);
                    int poolStrideSize = Try<int>(poolParamDict, "stride", 1);
                    int poolPad = Try<int>(poolParamDict, "pad", 0);
                    var poolParam = PoolLayerParam(
                        poolKernelSize, 
                        poolType == "MAX" ? PoolingLayerKind.Max : PoolingLayerKind.Average,
                        poolStrideSize,
                        poolPad);
                    return PoolLayer(name, poolParam);

                default:
                    // TODO checkk all types and throw exception if no type match
                    //throw new InvalidOperationException("Unklnown layer type!");
                    return null;
            }
        }

        private T Try<T>(dynamic dict, string path, T @default = default(T))
        {
            var result = @default;

            try
            {
                result = (T)dict[path];
            }
            catch
            { // ignore and use default
            }

            return result;
        }

        private T Try<T>(dynamic dict, string path, string subPath, T @default = default(T))
        {
            return Try(Try(dict, path, @default), subPath, @default);
        }

        public List<dynamic> FromLayers()
        {
            return (List<dynamic>)Properties["layer"];
        }
        
    }
    
}
