using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Prefab;
using Titan.Core.Syntax;

namespace Titan.Plugin.GraphViz.CodeGen
{
    internal class CodeGenWriter : SyntaxTreeWalker
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private NetworkSyntax _network;

        protected override void NetworkSyntaxEnter(NetworkSyntax network)
        {
            if (network == null) return;
            _network = network;
            _builder.Append($"digraph {network.Name} {{\n");
        }
        
        protected override void LayerSyntaxEnter(LayerSyntax layer)
        {
            if (layer == null) return;
            if (layer.ParentLayer == null)
            {
                _builder.Append($"\t{layer.Name} -> {_network.Name};\n");
            }
            else
            {
                _builder.Append($"\t{layer.Name} -> {layer.ParentLayer.Name};\n");
            }
        }

        protected override void OutputLayerEnter(OutputLayerSyntax outputLayer)
        {
            if (outputLayer == null) return;
            foreach (var input in _network.InputLayers)
            {
                _builder.Append($"\t{outputLayer.Name} -> {input.Name};\n");
            }
        }

        protected override void NetworkSyntaxExit(NetworkSyntax network) => _builder.Append($"}}\n");
        
        public string Build(NetworkSyntax network)
        {
            Traverse(network);
            return _builder.ToString();
        }
    }
}
