using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Vertex
{
    public static class VertexFactory
    {
        public static DimensionData Dimension(
            int height = DimensionData.DefaultHeightDimension,
            int width = DimensionData.DefaultWidthDimension,
            int channels = DimensionData.DefaultChannelsDimension)
        {
            return new DimensionData
            {
                Height = height,
                Width = width,
                Channels = channels
            };
        }

        public static InputLayerParameter InputLayerParam(
            int cropSize = Vertex.InputLayerParameter.DefaultCropSize,
            int batchSize = Vertex.InputLayerParameter.DefaultBatchSize,
            bool mirror = false)
        {
            return new Vertex.InputLayerParameter
            {
                BatchSize = batchSize,
                CropSize = cropSize,
                Mirror = mirror
            };
        }

        public static InputLayerVertex InputLayer(string name, DimensionData dimension = null, InputLayerParameter parameter = null)
        {
            return new Vertex.InputLayerVertex(name)
            {
                DimensionData = dimension ?? DimensionData.Default,
                Parameter = parameter ?? InputLayerParam()
            };
        }

        public static ConvolutionalLayerParameter ConvLayerParam(
            int kernelSize, 
            int numberOfOutput,
            int padding = 0,
            int stride = 1,
            bool biasTerm = false)
        {
            return new ConvolutionalLayerParameter()
            {
                KernelSize = kernelSize,
                NumberOfOutput = numberOfOutput,
                Padding = padding,
                Stride = stride,
                BiasTerm = biasTerm
            };
        }

        public static ConvolutionalLayerVertex ConvLayer(string name, 
            ConvolutionalLayerParameter parameter)
        {
            return new ConvolutionalLayerVertex(name, parameter);
        }

        public static PoolingLayerParameter PoolLayerParam(
            int kernelSize,
            PoolingLayerKind poolingKind = PoolingLayerKind.Max,
            int stride = 1)
        {
            return new PoolingLayerParameter
            {
                KernelSize = kernelSize,
                PoolingKind = poolingKind,
                Stride = stride
            };
        }

        public static PoolingLayerVertex PoolLayer(string name,
            PoolingLayerParameter parameter)
        {
            return new PoolingLayerVertex(name, parameter);
        }

        public static BatchNormalizationLayerVertex BatchNormLayer(string name, bool useGlobalStats = false)
        {
            return new BatchNormalizationLayerVertex
            {
                UseGlobalStats = useGlobalStats
            };
        }

        public static ScaleLayerVertex ScaleLayer(string name, bool biasTerm = false)
        {
            return new ScaleLayerVertex
            {
                BiasTerm = biasTerm
            };
        }

        public static ActivationLayerVertex ActivationLayer(string name,
            ActivationFunctionType activationType  = ActivationFunctionType.ReLU)
        {
            return new ActivationLayerVertex
            {
                ActivationFunction = activationType
            };
        }

        public static DropoutLayerVertex DropoutLayer(string name, float rate)
        {
            return new DropoutLayerVertex
            {
                Rate = rate
            };
        }

    }
}
