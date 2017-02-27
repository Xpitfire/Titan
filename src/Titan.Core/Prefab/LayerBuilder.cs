using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Core.Prefab
{
    public static class LayerBuilder
    {

        public static LayerSyntax Convolution1X1()
        {
            return new ConvolutionalLayerSyntax("con1x1");
        }

    }
}
