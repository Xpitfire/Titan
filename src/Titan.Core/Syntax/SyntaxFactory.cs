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
        public static IdentifierSyntax Spix(string name = null) => new IdentifierSyntax(name);

        public static NetworkSyntax Network(
            NetworkParameterSyntax parameter,
            InputLayerSyntax trainLayer,
            InputLayerSyntax validationLayer = null,
            InputLayerSyntax testLayer = null, 
            string name = null) => new NetworkSyntax(parameter, trainLayer, validationLayer, testLayer, name);
        public static NetworkSyntax Network(string name = null) => Network(NetworkParameter(), null, name: name);
        public static NetworkSyntax Network(NetworkParameterSyntax parameter) => Network(parameter, null);

        public static InputLayerSyntax InputLayer(InputLayerKind type, string name = null) => InputLayer(type, Syntax.Data.Empty, Label.Empty, name: name);
        public static InputLayerSyntax InputLayer(InputLayerKind type, Data data, Label label, InputLayerParameterSyntax parameter = null, string name = null) => new InputLayerSyntax(type, data, label, parameter, name);
        
        public static Data Data(ImmutableList<float[]> dataVector, int format, int channels) => new Data(dataVector, format, format, channels);

        public static NetworkParameterSyntax NetworkParameter(
            int epochs = NetworkParameterSyntax.DefaultEpochSize,
            NetworkParameterSyntax.UpdaterType updater = NetworkParameterSyntax.DefaultUpdaterType,
            float learningRate = NetworkParameterSyntax.DefaultLearningRate,
            int batchSize = NetworkParameterSyntax.DefaultBatchSize,
            int seed = NetworkParameterSyntax.DefaultSeedValue) => new NetworkParameterSyntax(epochs, updater, learningRate, batchSize, seed);
        
        public static OutputLayerSyntax OutputLayer(string name = null) => new OutputLayerSyntax(name);
        public static LayerSyntax PoolingLayer() => new PoolingLayerSyntax();

        public static ConvolutionalLayerSyntax ConvolutionalLayer(string name = null) => new ConvolutionalLayerSyntax(name);
    }
}
