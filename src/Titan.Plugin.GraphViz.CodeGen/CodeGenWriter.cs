using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Prefab;
using Titan.Core.Syntax;

namespace Titan.Plugin.GraphViz.CodeGen
{
    [SyntaxNodeVisitor]
    internal class CodeGenWriter
    {
        private static readonly StringBuilder Builder = new StringBuilder();
        private static NetworkSyntax network;
        
        public static void NetworkSyntaxInAction(NetworkSyntax network)
        {
            if (network == null) return;
            CodeGenWriter.network = network;
            Builder.Append($"digraph {network.Name} {{\n");
        }
        
        protected static void LayerSyntaxPostAction(LayerSyntax layer)
        {
            if (layer == null) return;
            Builder.Append($"\t{layer.Name} -> {network.Name};\n");
        }

        protected static void OutputLayerEnter(OutputLayerSyntax outputLayer)
        {
            if (outputLayer == null) return;
            foreach (var input in network.Layers)
            {
                Builder.Append($"\t{outputLayer.Name} -> {input.Name};\n");
            }
        }

        public static void NetworkSyntaxPostAction() => Builder.Append($"}}\n");
        
        public static string Build(NetworkSyntax network)
        {
            Builder.Clear();
            CodeGenWriter.network = network;
            CodeGenWriter.network.Traverse();
            return Builder.ToString();
        }

    }
}
