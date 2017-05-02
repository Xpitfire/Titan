using System;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public abstract class VertexBase : IVertex
    {
        public Identifier Identifier { get; }
        public string Name { get; internal set; }

        private VertexBase() { }
        protected VertexBase(string name) : this(new Identifier(name))
        {
        }

        protected VertexBase(Identifier identifier)
        {
            Identifier = identifier;
            Name = Identifier.Id;
        }

        public object Clone() => this.DeepClone();

        protected bool Equals(VertexBase other)
        {
            return Equals(Identifier, other.Identifier);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((VertexBase) obj);
        }

        public override int GetHashCode()
        {
            return Identifier?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return GetType().Name;
        }
}
}
