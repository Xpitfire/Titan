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
            InputLayerSyntax trainLayer,
            InputLayerSyntax validationLayer = null,
            InputLayerSyntax testLayer = null) => new NetworkSyntax(parameter, trainLayer, validationLayer, testLayer, name);
        public static NetworkSyntax Network(string name) => Network(name, NetworkParameter(), null);
        public static NetworkSyntax Network(string name, NetworkParameterSyntax parameter) => Network(name, parameter, null);

        public static InputLayerSyntax InputLayer(string name, InputLayerKind type = InputLayerKind.Train) => InputLayer(name, Dimension.Default, Label.Empty, type: type);
        public static InputLayerSyntax InputLayer(string name, Dimension data, Label label, InputLayerParameterSyntax parameter = null, InputLayerKind type = InputLayerKind.Train) => new InputLayerSyntax(type, data, label, parameter, name);
        
        public static Dimension Data(int format, int channels) => new Dimension(format, format, channels);

        public static NetworkParameterSyntax NetworkParameter(
            int epochs = NetworkParameterSyntax.DefaultEpochSize,
            NetworkParameterSyntax.UpdaterType updater = NetworkParameterSyntax.DefaultUpdaterType,
            float learningRate = NetworkParameterSyntax.DefaultLearningRate,
            int batchSize = NetworkParameterSyntax.DefaultBatchSize,
            int seed = NetworkParameterSyntax.DefaultSeedValue) => new NetworkParameterSyntax(epochs, updater, learningRate, batchSize, seed);
        
        public static LayerSyntax PoolingLayer(string name, string input) => new PoolingLayerSyntax(name, input);
        public static ConvolutionalLayerSyntax ConvolutionalLayer(string name, string input) => new ConvolutionalLayerSyntax(name);
        public static OutputLayerSyntax OutputLayer(string name, string input) => new OutputLayerSyntax(name);

    }
}
