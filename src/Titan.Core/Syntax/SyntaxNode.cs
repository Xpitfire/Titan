using System;
namespace Titan.Core.Syntax
{
    [Serializable]
    public delegate void VisitorDelegate<in TNode>(TNode node) where TNode : SyntaxNode;

    [Serializable]
    public abstract class SyntaxNode : ICloneable
    {
        public IdentifierSyntax Identifier { get; internal set; }
        private string _name;
        public string Name {
            get { return _name ?? Identifier.Id; }
            internal set { _name = value; }
        }

        protected SyntaxNode() : this(new IdentifierSyntax()) { }
        protected SyntaxNode(string name = null) : this(new IdentifierSyntax(name)) { }
        protected SyntaxNode(IdentifierSyntax identifier, string name = null)
        {
            Identifier = identifier;
            if (name != null)
            {
                Name = name;
            }
        }

        public object Clone() => this.Clone<SyntaxNode>();
        internal virtual void Visit() { }
    }
}
