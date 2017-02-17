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
        private static StringBuilder _builder = new StringBuilder();
        private static NetworkSyntax _network;
        
        public static void NetworkSyntaxInAction(NetworkSyntax network)
        {
            if (network == null) return;
            _network = network;
            _builder.Append($"digraph {network.Name} {{\n");
        }
        
        protected static void LayerSyntaxPostAction(LayerSyntax layer)
        {
            if (layer == null) return;
            _builder.Append($"\t{layer.Name} -> {_network.Name};\n");
        }

        protected static void OutputLayerEnter(OutputLayerSyntax outputLayer)
        {
            if (outputLayer == null) return;
            foreach (var input in _network.InputLayers)
            {
                _builder.Append($"\t{outputLayer.Name} -> {input.Name};\n");
            }
        }

        public static void NetworkSyntaxPostAction() => _builder.Append($"}}\n");
        
        public static string Build(NetworkSyntax network)
        {
            _builder.Clear();
            _network = network;
            _network.Traverse();
            return _builder.ToString();
        }

    }
}
