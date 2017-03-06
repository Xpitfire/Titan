using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph
{
    public static class GraphOperatorExtension
    {
        public static Network AddCycles(this Network network, LayerVertex layerVertex, params LayerVertex[] layerVertices)
        {
            if (layerVertices == null || layerVertices.Length <= 0) return network;
            network.AddVertex(layerVertex);
            foreach (var vertex in layerVertices)
            {
                if (vertex == null) continue;

                network.AddVertex(vertex);
                network.AddEdge(layerVertex.Name, vertex.Name, cycle: true);
            }
            return network;
        }

        public static Network AddLayer(
            this Network network,
            LayerVertex layer,
            ActivationLayerVertex activationLayer = null,
            BatchNormalizationLayerVertex batchNormalizationLayer = null,
            ScaleLayerVertex scaleLayer = null,
            DropoutLayerVertex dropoutLayer = null)
        {
            return network.AddCycles(layer,
                activationLayer, batchNormalizationLayer, scaleLayer, dropoutLayer);
        }

        public static Network AddConvolutionalBlock(
            this Network network,
            ConvolutionalLayerVertex convolutionalLayer,
            params LayerVertex[] paramLayers)
        {
            network.AddVertex(convolutionalLayer);
            network.AddVertices(paramLayers);

            foreach (var layerVertex in paramLayers)
            {
                network.AddCycles(convolutionalLayer, layerVertex);
            }
            return network;
        }

        public static Network AddSequence(
            this Network network,
            LayerVertex[] sequence)
        {
            network.AddVertices(sequence);

            for (var i = 0; i < sequence.Length - 1; i++)
            {
                network.AddEdge(sequence[i].Name, sequence[i + 1].Name);
            }
            return network;
        }

        public static Network AddResidualBlock(
            this Network network,
            LayerVertex layerRoot,
            LayerVertex[] leftBranch,
            LayerVertex[] rightBranch,
            EltwiseLayerVertex eltwiseLayer)
        {
            network.AddVertex(layerRoot);
            network.AddVertex(eltwiseLayer);
            network.AddSequence(leftBranch);
            network.AddSequence(rightBranch);

            network.AddEdge(layerRoot.Name, leftBranch.First().Name);
            network.AddEdge(layerRoot.Name, rightBranch.First().Name);
            network.AddEdge(leftBranch.Last().Name, eltwiseLayer.Name);
            network.AddEdge(rightBranch.Last().Name, eltwiseLayer.Name);
            return network;
        }

        public static Network AddInceptionBlock(
            this Network network,
            LayerVertex layerRoot,
            LayerVertex[] branches,
            EltwiseLayerVertex eltwiseLayer)
        {
            network.AddVertex(layerRoot);
            network.AddVertices(branches);
            network.AddVertex(eltwiseLayer);

            foreach (var layerVertex in branches)
            {
                network.AddEdge(layerRoot.Name, layerVertex.Name);
                network.AddEdge(layerVertex.Name, eltwiseLayer.Name);
            }
            return network;
        }

        public static Network AddInceptionBlock(
            this Network network,
            LayerVertex layerRoot,
            LayerVertex[][] branches,
            EltwiseLayerVertex eltwiseLayer)
        {
            network.AddVertex(layerRoot);
            network.AddVertex(eltwiseLayer);

            foreach (var branch in branches)
            {
                network.AddSequence(branch);
                network.AddEdge(layerRoot.Name, branch.First().Name);
                network.AddEdge(branch.Last().Name, eltwiseLayer.Name);
            }
            return network;
        }
    }
}
