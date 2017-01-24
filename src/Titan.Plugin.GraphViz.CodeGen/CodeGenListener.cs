using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Plugin.GraphViz.CodeGen
{
    internal class CodeGenListener : IDisposable
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public CodeGenListener()
        {
            NetworkSyntax.VisitedEvent += VisitNetwork;
            NetworkParameterSyntax.VisitedEvent += VisitNetworkParam;
            InputLayerSyntax.VisitedEvent += VisitInputLayer;
        }

        public void Dispose()
        {
            NetworkSyntax.VisitedEvent -= VisitNetwork;
            NetworkParameterSyntax.VisitedEvent -= VisitNetworkParam;
            InputLayerSyntax.VisitedEvent -= VisitInputLayer;
        }

        private void VisitNetwork(NetworkSyntax node)
        {
            _builder.Append($"network {node.Name} {{\n");
        }

        private void VisitNetworkParam(NetworkParameterSyntax node)
        {
            _builder.Append($"{node.Name} -> {node.BatchSize}\n");
        }

        private void VisitInputLayer(InputLayerSyntax node)
        {
            _builder.Append($"{node.Name} -> {node.Kind}\n");
        }


        public string Build()
        {
            return _builder.ToString();
        }
    }
}
