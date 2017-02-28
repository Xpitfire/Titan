using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;
using Titan.Core.Syntax;

namespace Titan.Core.Prefab
{
    public static class LayerBuilder
    {

        public static LayerSyntax Convolution1X1()
        {
            return new ConvolutionalLayerSyntax("con1x1");
        }

        public static NetworkSyntax ResNet50()
        {
            var resNet50 = new NetworkSyntax("ResNet-50");
            var data = new InputLayerSyntax("data");
            var conv1Block = ConvolutionalBlock("conv1");
            var pool1 = new PoolingLayerSyntax("pool1", 
                new PoolingParameterSyntax(PoolingLayerKind.Max, kernelSize: 3, stride: 2));

            var left


            return resNet50;
        }

        public static ImmutableList<SyntaxNode> ConvolutionalBlock(string name)
        {
            var conv1 = new ConvolutionalLayerSyntax(name,
                new ConvolutionalParameterSyntax(
                    ActivationFunctionType.ReLU,
                    numberOfOutput: 64,
                    kernelSize: 7,
                    padding: 3,
                    stride: 2));
            var bnConv1 = new BatchNormalizationLayerSyntax($"bn_{name}");
            var scaleConv1 = new ScaleLayerSyntax($"scale_{name}");
            return conv1.Add(bnConv1).Merge(scaleConv1);
        }

        public static ResidualLayerSyntax ResidualBlock(SyntaxNode input)
        {
            var leftBranch;
            var rightBranch;

            var residualLayer = new ResidualLayerSyntax("res2a", input, leftBranch, rightBranch);
            return residualLayer;
        }

    }
}
