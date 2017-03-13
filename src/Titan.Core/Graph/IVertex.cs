using System;

namespace Titan.Core.Graph.Vertex
{
    public interface IVertex : ICloneable
    {
        Identifier Identifier { get; }
    }
}
