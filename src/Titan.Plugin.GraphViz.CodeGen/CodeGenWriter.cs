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

        protected override void NetworkSyntaxEnter(NetworkSyntax network)
        {
            if (network == null) return;
            _builder.Append($"digraph {network.Name} {{\n");
        }
        
        protected override void LayerSyntaxEnter(LayerSyntax layer)
        {
            if (layer == null || layer.ParentLayers == null) return;
            foreach (var prevLayer in layer.ParentLayers)
            {
                _builder.Append($"\t{layer.Name} -> {prevLayer.Name};\n");
            }
        }

        protected override void OutputLayerEnter(NetworkSyntax network, OutputLayerSyntax outputLayer)
        {
            if (outputLayer == null) return;
            foreach (var input in network.InputLayers)
            {
                if (input.InputKind == InputLayerKind.Train)
                {
                    foreach (var prevLayer in outputLayer.ParentLayers)
                    {
                        _builder.Append($"\t{outputLayer.Name} -> {prevLayer.Name};\n");
                    }
                }
                else
                {
                    _builder.Append($"\t{outputLayer.Name} -> {input.Name};\n");
                }
            }
        }

        protected override void NetworkSyntaxExit(NetworkSyntax network) => _builder.Append($"}}\n");
        
        public string Build(SyntaxNode syntaxNode)
        {
            Traverse(syntaxNode);
            return _builder.ToString();
        }
    }
}
