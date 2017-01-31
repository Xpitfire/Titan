using Titan.Core.Syntax;

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

                if (network.InputLayers != null)
                {
                    foreach (var inputLayer in network.InputLayers)
                    {
                        InputLayerEnter(inputLayer);
                        InputLayerEnter(network, inputLayer);
                        Traverse(inputLayer);
                        InputLayerExit(inputLayer);
                        InputLayerExit(network, inputLayer);
                    }
                }
                
                if (network.Layers != null)
                {
                    foreach (var layer in network.Layers)
                    {
                        LayerSyntaxEnter(layer);
                        LayerSyntaxEnter(network, layer);
                        Traverse(layer);
                        LayerSyntaxExit(layer);
                        LayerSyntaxExit(network, layer);
                    }
                }           
                
                if (network.OutputLayers != null)
                {
                    foreach (var outputLayer in network.OutputLayers)
                    {
                        OutputLayerEnter(outputLayer);
                        OutputLayerEnter(network, outputLayer);
                        Traverse(outputLayer);
                        OutputLayerExit(outputLayer);
                        OutputLayerExit(network, outputLayer);
                    }
                }

                NetworkSyntaxExit(network);
            }

            node.Visit();
        }

        protected virtual void NetworkSyntaxEnter(NetworkSyntax network) { }
        protected virtual void NetworkSyntaxExit(NetworkSyntax network) { }
        protected virtual void NetworkParameterSyntaxEnter(NetworkParameterSyntax networkParameter) { }
        protected virtual void NetworkParameterSyntaxExit(NetworkParameterSyntax networkParameter) { }
        protected virtual void LayerSyntaxEnter(LayerSyntax layer) { }
        protected virtual void LayerSyntaxExit(LayerSyntax layer) { }
        protected virtual void LayerSyntaxEnter(NetworkSyntax network, LayerSyntax layer) { }
        protected virtual void LayerSyntaxExit(NetworkSyntax network, LayerSyntax layer) { }
        protected virtual void InputLayerEnter(InputLayerSyntax inputLayer) { }
        protected virtual void InputLayerExit(InputLayerSyntax inputLayer) { }
        protected virtual void InputLayerEnter(NetworkSyntax network, InputLayerSyntax inputLayer) { }
        protected virtual void InputLayerExit(NetworkSyntax network, InputLayerSyntax inputLayer) { }
        protected virtual void OutputLayerEnter(OutputLayerSyntax outputLayer) { }
        protected virtual void OutputLayerExit(OutputLayerSyntax outputLayer) { }
        protected virtual void OutputLayerEnter(NetworkSyntax network, OutputLayerSyntax outputLayer) { }
        protected virtual void OutputLayerExit(NetworkSyntax network, OutputLayerSyntax outputLayer) { }

    }
}
