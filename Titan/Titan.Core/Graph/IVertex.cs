using System;

namespace Titan.Core.Graph
{
    public interface IVertex : ICloneable
    {
        Identifier Identifier { get; }
    }
}
