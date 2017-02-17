using Titan.Core.Syntax;

namespace Titan.Core.Prefab
{
    public class SyntaxTreeWalker
    {
        protected void Traverse(NetworkSyntax network)
        {
            if (network == null) return;
            network.NodeEnterEvent.
            OnNetworkSyntaxEnter();
            network.Visit<NetworkSyntax>(OnNetworkSyntaxVisit);
            network.Parameter?.Visit<NetworkParameterSyntax>(NetworkParameterSyntax);
            NetworkParameterSyntax(network.Parameter);

            if (network.InputLayers != null)
            {
                foreach (var inputLayer in network.InputLayers)
                {
                    InputLayerEnter(inputLayer);
                    inputLayer.Traverse()
                    Traverse(inputLayer);
                    InputLayerExit(inputLayer);
                }
            }

            if (network.Layers != null)
            {
                foreach (var layer in network.Layers)
                {
                    LayerSyntaxEnter(layer);
                    Traverse(layer);
                    LayerSyntaxExit(layer);
                }
            }

            if (network.OutputLayers != null)
            {
                foreach (var outputLayer in network.OutputLayers)
                {
                    OutputLayerEnter(outputLayer);
                    Traverse(outputLayer);
                    OutputLayerExit(outputLayer);
                }
            }

            NetworkSyntaxPostAction(network);
        }

        protected void Traverse(LayerSyntax layer)
        {
            if (layer == null) return;
            layer.Visit();
        }

        protected void Traverse(InputLayerSyntax layer)
        {
            if (layer == null) return;
            layer.Visit();
        }

        protected void Traverse(OutputLayerSyntax layer)
        {
            if (layer == null) return;
            layer.Visit();
        }

        protected void Traverse(NetworkParameterSyntax param)
        {
            if (param == null) return;
            param.Visit();
        }

        protected virtual void OnNetworkSyntaxEnter() { }
        protected virtual void OnNetworkSyntaxVisit(NetworkSyntax node) { }
        protected virtual void OnNetworkSyntaxLeave() { }
        protected virtual void NetworkParameterSyntax(NetworkParameterSyntax networkParameter) { }
        protected virtual void NetworkParameterSyntaxExit(NetworkParameterSyntax networkParameter) { }
        protected virtual void LayerSyntaxEnter(LayerSyntax layer) { }
        protected virtual void LayerSyntaxExit(LayerSyntax layer) { }
        protected virtual void InputLayerEnter(InputLayerSyntax inputLayer) { }
        protected virtual void InputLayerExit(InputLayerSyntax inputLayer) { }
        protected virtual void OutputLayerEnter(OutputLayerSyntax outputLayer) { }
        protected virtual void OutputLayerExit(OutputLayerSyntax outputLayer) { }
    }
}
