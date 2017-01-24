using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    public static class SyntaxTreeWalker
    {
        public static void Walk(SyntaxNode node)
        {
            if (node == null) return;

            var network = node as NetworkSyntax;
            if (network != null)
            {
                network.Traverse();
                Walk(network.Parameter);
                Walk(network.TrainLayer);
                Walk(network.ValidationLayer);
                Walk(network.TestLayer);
                return;
            }

            node.Traverse();

            //var networkParam = node as NetworkParameterSyntax;
            //networkParam?.Traverse();

            //var inputLayer = node as InputLayerSyntax;
            //inputLayer?.Traverse();

            //var outputLayer = node as OutputLayerSyntax;
            //outputLayer?.Traverse();

            //var convLayer = node as ConvolutionalLayerSyntax;
            //convLayer?.Traverse();

            //var poolLayer = node as PoolingLayerSyntax;
            //poolLayer?.Traverse();
        }
    }
}
