using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    public static class SyntaxFactory
    {
        public static Spix Spix(string name = null) => new Spix(name);

        public static NetworkSyntax Network(
            NetworkParameterSyntax parameter,
            InputLayerSyntax trainLayer,
            InputLayerSyntax validationLayer = null,
            InputLayerSyntax testLayer = null, 
            string name = null) => new NetworkSyntax(parameter, trainLayer, validationLayer, testLayer, name);
        public static NetworkSyntax Network(string name = null) => Network(NetworkParameter(), null, name: name);
        public static NetworkSyntax Network(NetworkParameterSyntax parameter) => Network(parameter, null);

        public static InputLayerSyntax InputLayer(InputLayerType type, string name = null) => InputLayer(type, Syntax.InputMatrix.DefaultInputMatrix, name);
        public static InputLayerSyntax InputLayer(InputLayerType type, InputMatrix inputMatrix, string name = null) => new InputLayerSyntax(type, inputMatrix, name);

        public static InputMatrix InputMatrix() => Syntax.InputMatrix.DefaultInputMatrix;
        public static InputMatrix InputMatrix(int format, int channels) => new InputMatrix(format, format, channels);

        public static NetworkParameterSyntax NetworkParameter(
            int epochs = NetworkParameterSyntax.DefaultEpochSize,
            NetworkParameterSyntax.UpdaterType updater = NetworkParameterSyntax.DefaultUpdaterType,
            float learningRate = NetworkParameterSyntax.DefaultLearningRate,
            int batchSize = NetworkParameterSyntax.DefaultBatchSize,
            int seed = NetworkParameterSyntax.DefaultSeedValue) => new NetworkParameterSyntax(epochs, updater, learningRate, batchSize, seed);

        public static ConvolutionalLayerSyntax ConvolutionalLayer(string name = null) => new ConvolutionalLayerSyntax(name);
    }
}
