using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    public static class SyntaxTreeWalker
    {
        public static void Walk(SyntaxNode node)
        {
            if (node == null) return;
            node.Traverse();

            var network = node as NetworkSyntax;
            if (network != null)
            {
                Walk(network.Parameter);
                Walk(network.TrainLayer);
                Walk(network.ValidationLayer);
                Walk(network.TestLayer);
                Walk(network.NextLayer);
            }

            var layer = node as LayerSyntax;
            if (layer != null)
            {
                Walk(layer.NextLayer);
            }
        }
    }
}
