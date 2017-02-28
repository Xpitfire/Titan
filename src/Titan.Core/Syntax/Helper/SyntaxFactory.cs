using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    public static class SyntaxFactory
    {
        public static NetworkSyntax Network(
            string name,
            NetworkParameterSyntax parameter,
            ImmutableList<SyntaxNode> layers) => new NetworkSyntax(name, parameter);
        public static NetworkSyntax Network(string name) => Network(name, NetworkParameter(), null);
        public static NetworkSyntax Network(string name, NetworkParameterSyntax parameter) => Network(name, parameter, null);

        public static InputLayerSyntax InputLayer(string name, InputLayerKind type = InputLayerKind.Train) => InputLayer(name, DimensionData.Default, LabelData.Empty, type: type);
        public static InputLayerSyntax InputLayer(string name, DimensionData dimensionData, LabelData labelData, InputLayerParameterSyntax parameter = null, InputLayerKind type = InputLayerKind.Train) => new InputLayerSyntax(name, type, dimensionData, labelData, parameter);
        
        public static DimensionData Data(int format, int channels) => new DimensionData(format, format, channels);

        public static NetworkParameterSyntax NetworkParameter(
            int epochs = NetworkParameterSyntax.DefaultEpochSize,
            NetworkParameterSyntax.UpdaterType updater = NetworkParameterSyntax.DefaultUpdaterType,
            float learningRate = NetworkParameterSyntax.DefaultLearningRate,
            int batchSize = NetworkParameterSyntax.DefaultBatchSize,
            int seed = NetworkParameterSyntax.DefaultSeedValue) => new NetworkParameterSyntax(epochs, updater, learningRate, batchSize, seed);
        
        public static LayerSyntax PoolingLayer(string name) => new PoolingLayerSyntax(name);
        public static ConvolutionalLayerSyntax ConvolutionalLayer(string name, string input) => new ConvolutionalLayerSyntax(name);
        public static OutputLayerSyntax OutputLayer(string name, string input) => new OutputLayerSyntax(name);

    }
}
