﻿using Titan.Core.Syntax;

namespace Titan.Core.Prefab
{
    public class SyntaxTreeWalker
    {
        protected void Traverse(SyntaxNode node)
        {
            if (node == null) return;

            var network = node as NetworkSyntax;
            if (network != null)
            {
                NetworkSyntaxEnter(network);

                NetworkParameterSyntaxEnter(network.Parameter);
                Traverse(network.Parameter);
                NetworkParameterSyntaxEnter(network.Parameter);

                InputLayerEnter(network.TrainLayer);
                Traverse(network.TrainLayer);
                InputLayerExit(network.TrainLayer);

                InputLayerEnter(network.ValidationLayer);
                Traverse(network.ValidationLayer);
                InputLayerExit(network.ValidationLayer);

                InputLayerEnter(network.TestLayer);
                Traverse(network.TestLayer);
                InputLayerExit(network.TestLayer);

                LayerSyntaxEnter(network.NextLayer);
                Traverse(network.NextLayer);
                LayerSyntaxEnter(network.NextLayer);

                NetworkSyntaxExit(network);
            }

            var layer = node as LayerSyntax;
            if (layer != null)
            {
                LayerSyntaxEnter(layer.NextLayer);
                Traverse(layer.NextLayer);
                LayerSyntaxExit(layer.NextLayer);
            }
        }

        protected virtual void NetworkSyntaxEnter(NetworkSyntax network) { }
        protected virtual void NetworkSyntaxExit(NetworkSyntax network) { }
        protected virtual void NetworkParameterSyntaxEnter(NetworkParameterSyntax networkParameter) { }
        protected virtual void NetworkParameterSyntaxExit(NetworkParameterSyntax networkParameter) { }
        protected virtual void LayerSyntaxEnter(LayerSyntax layer) { }
        protected virtual void LayerSyntaxExit(LayerSyntax layer) { }
        protected virtual void InputLayerEnter(InputLayerSyntax inputLayer) { }
        protected virtual void InputLayerExit(InputLayerSyntax inputLayer) { }

    }
}
