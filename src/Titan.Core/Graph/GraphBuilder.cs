using System.Linq;
using Titan.Core.Collection;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    public static class GraphBuilder
    {

        public static LayerVertex BuildConvolution1X1Out64(string name)
        {
            return new ConvolutionalLayerVertex(name, new ConvolutionalParameter(
                numberOfOutput: 64,
                    kernelSize: 1,
                    padding: 1,
                    stride: 1,
                    biasTerm: true));
        }

        public static LayerVertex BuildConvolution1X1Out128(string name)
        {
            return new ConvolutionalLayerVertex(name, new ConvolutionalParameter(
                numberOfOutput: 128,
                    kernelSize: 1,
                    padding: 1,
                    stride: 1,
                    biasTerm: true));
        }

        

        
    }
}
