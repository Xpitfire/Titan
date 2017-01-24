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
            LayerSyntax.VisitedEvent += VisitNextLayer;
        }

        public void Dispose()
        {
            NetworkSyntax.VisitedEvent -= VisitNetwork;
            NetworkParameterSyntax.VisitedEvent -= VisitNetworkParam;
            InputLayerSyntax.VisitedEvent -= VisitInputLayer;
        }

        private void VisitNetwork(NetworkSyntax node)
        {
            _builder.Append($"Network: {node.Name}\n");
        }

        private void VisitNetworkParam(NetworkParameterSyntax node)
        {
            _builder.Append($"NetworkParam: {node.Name} -> {node.BatchSize}\n");
        }

        private void VisitInputLayer(InputLayerSyntax node)
        {
            _builder.Append($"InputLayer: {node.Name} -> {node.Kind}\n");
        }

        private void VisitNextLayer(LayerSyntax node)
        {
            _builder.Append($"NextLayer: {node.Name} -> {node.Kind}\n");
        }


        public string Build()
        {
            return _builder.ToString();
        }
    }
}
