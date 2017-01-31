using Titan.Core.Syntax;

namespace Titan.Core.Prefab
{
    public class SyntaxTreeWalker
    {
        protected void Traverse(NetworkSyntax network)
        {
            if (network == null) return;
            NetworkSyntaxEnter(network);

            NetworkParameterSyntaxEnter(network.Parameter);
            Traverse(network.Parameter);
            NetworkParameterSyntaxEnter(network.Parameter);

            if (network.InputLayers != null)
            {
                foreach (var inputLayer in network.InputLayers)
                {
                    InputLayerEnter(inputLayer);
                    Traverse(inputLayer);
                    InputLayerExit(inputLayer);
                }
            }

            if (network.RootLayer != null)
            {
                Traverse(network.RootLayer);
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

            NetworkSyntaxExit(network);
        }

        protected void Traverse(LayerSyntax layer)
        {
            if (layer == null) return;
            if (layer.ChildLayers != null)
            {
                foreach (var child in layer.ChildLayers)
                {
                    LayerSyntaxEnter(layer);
                    Traverse(child);
                    LayerSyntaxExit(layer);
                }
            }
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

        protected virtual void NetworkSyntaxEnter(NetworkSyntax network) { }
        protected virtual void NetworkSyntaxExit(NetworkSyntax network) { }
        protected virtual void NetworkParameterSyntaxEnter(NetworkParameterSyntax networkParameter) { }
        protected virtual void NetworkParameterSyntaxExit(NetworkParameterSyntax networkParameter) { }
        protected virtual void LayerSyntaxEnter(LayerSyntax layer) { }
        protected virtual void LayerSyntaxExit(LayerSyntax layer) { }
        protected virtual void InputLayerEnter(InputLayerSyntax inputLayer) { }
        protected virtual void InputLayerExit(InputLayerSyntax inputLayer) { }
        protected virtual void OutputLayerEnter(OutputLayerSyntax outputLayer) { }
        protected virtual void OutputLayerExit(OutputLayerSyntax outputLayer) { }
    }
}
