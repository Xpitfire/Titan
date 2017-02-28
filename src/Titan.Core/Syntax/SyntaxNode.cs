using System;
using Titan.Core.CodeGen;

namespace Titan.Core.Syntax
{
    [Serializable]
    public abstract class SyntaxNode : ICloneable
    {
        public Identifier Identifier { get; internal set; }
        private string _name;
        public string Name {
            get { return _name ?? Identifier.Id; }
            internal set { _name = value; }
        }

        protected SyntaxNode() : this(new Identifier()) { }
        protected SyntaxNode(string name = null) : this(new Identifier(name)) { }
        protected SyntaxNode(Identifier identifier, string name = null)
        {
            Identifier = identifier;
            if (name != null)
            {
                Name = name;
            }
        }

        public object Clone() => this.DeepClone();
        
    }
}
