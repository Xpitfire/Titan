using System;
using Titan.Core.CodeGen;

namespace Titan.Core.Syntax
{
    [Serializable]
    public abstract class SyntaxNode : ICloneable
    {
        public Identifier Identifier { get; }
        private string _name;
        public string Name {
            get { return _name ?? Identifier.Id; }
            internal set { _name = value; }
        }

        protected SyntaxNode() : this(null) { }
        protected SyntaxNode(string name) : this(new Identifier(), name) { }
        protected SyntaxNode(Identifier identifier, string name = null)
        {
            Identifier = identifier;
            if (name != null)
            {
                Name = name;
            }
        }

        public object Clone() => this.DeepClone();

        protected bool Equals(SyntaxNode other)
        {
            return Equals(Identifier, other.Identifier);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SyntaxNode) obj);
        }

        public override int GetHashCode()
        {
            return (Identifier != null ? Identifier.GetHashCode() : 0);
        }
    }
}
