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
            _builder.Append($"digraph {network.Name}Graph {{\n");
            _builder.Append($"\t{network.TrainLayer?.Name} -> {network.Name};\n");       if (network.ValidationLayer == null) return;
            _builder.Append($"\t{network.ValidationLayer?.Name} -> {network.Name};\n");  if (network.TestLayer == null) return;
            _builder.Append($"\t{network.TestLayer?.Name} -> {network.Name};\n");
        }
        
        protected override void LayerSyntaxEnter(LayerSyntax layer)
        {
            if (layer == null || layer.PreviousLayer == null) return;
            _builder.Append($"\t{layer.Name} -> {layer.PreviousLayer.Name};\n");
        }

        protected override void NetworkSyntaxExit(NetworkSyntax network) => _builder.Append($"}}\n");
        
        public string Build(SyntaxNode syntaxNode)
        {
            Traverse(syntaxNode);
            return _builder.ToString();
        }
    }
}
