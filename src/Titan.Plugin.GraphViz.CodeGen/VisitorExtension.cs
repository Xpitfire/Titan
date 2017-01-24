using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Plugin.GraphViz.CodeGen
{
    internal static class VisitorExtension
    {
        public static void Traverse(this SyntaxNode node)
        {
            dynamic n = node as NetworkSyntax;
            if (n != null)
            {
                
            }

            n = node as LayerSyntax;
            
        }
        
    }
}
