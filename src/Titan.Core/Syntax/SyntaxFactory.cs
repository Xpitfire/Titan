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

        public static NetworkSyntax Network(NetworkParameterSyntax networkParameter) => new NetworkSyntax(networkParameter);
        public static NetworkSyntax Network() => Network(NetworkParameter());
        
        public static InputLayerSyntax InputLayer() => new InputLayerSyntax(InputMatrix());
        public static InputLayerSyntax InputLayer(InputMatrix inputMatrix) => new InputLayerSyntax(inputMatrix);

        public static InputMatrix InputMatrix() => InputLayerSyntax.DefaultInputMatrix;
        public static InputMatrix InputMatrix(int format, int channels) => new InputMatrix(format, format, channels);

        public static NetworkParameterSyntax NetworkParameter(
            int epochs = NetworkParameterSyntax.DefaultEpochSize,
            NetworkParameterSyntax.UpdaterType updater = NetworkParameterSyntax.DefaultUpdaterType,
            float learningRate = NetworkParameterSyntax.DefaultLearningRate,
            int batchSize = NetworkParameterSyntax.DefaultBatchSize,
            int seed = NetworkParameterSyntax.DefaultSeedValue) => new NetworkParameterSyntax(epochs, updater, learningRate, batchSize, seed);
    }
}
