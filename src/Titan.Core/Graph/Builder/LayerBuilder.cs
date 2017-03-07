using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.Graph.Builder
{
    public class LayerBuilder<TVertex> : IBuilder<TVertex> where TVertex : IVertex
    {

        public TVertex Vertex { get; internal set; }

        public LayerBuilder(TVertex vertex)
        {
            Vertex = vertex;
        }
        
        public static implicit operator TVertex(LayerBuilder<TVertex> builder)
        {
            return builder.Vertex;
        }

        public static implicit operator LayerBuilder<TVertex>(TVertex vertex)
        {
            return new LayerBuilder<TVertex>(vertex);
        }
    }
}
