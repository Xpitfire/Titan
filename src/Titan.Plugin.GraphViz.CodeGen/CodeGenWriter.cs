using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;

namespace Titan.Plugin.GraphViz.CodeGen
{
    internal class CodeGenWriter
    {
        private static readonly StringBuilder Builder = new StringBuilder();
        private static Network network;
        
        public static void NetworkSyntaxInAction(Network network)
        {
            if (network == null) return;
            CodeGenWriter.network = network;
            Builder.Append($"digraph {network.Name} {{\n");
        }
        
        protected static void LayerSyntaxPostAction(LayerVertex layer)
        {
            if (layer == null) return;
            Builder.Append($"\t{layer.Name} -> {network.Name};\n");
        }

        protected static void OutputLayerEnter(SoftmaxLayerVertex outputLayer)
        {
            if (outputLayer == null) return;
        }

        public static void NetworkSyntaxPostAction() => Builder.Append($"}}\n");
        
        public static string Build(Network network)
        {
            Builder.Clear();
            CodeGenWriter.network = network;
            return Builder.ToString();
        }

    }
}
