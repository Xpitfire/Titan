using System;
using Titan.Core.CodeGen;

namespace Titan.Core.Syntax
{
    [Serializable]
    [Traversable]
    public abstract class SyntaxNode : ICloneable
    {
        public event Action NodeEnterEvent;
        public event Action<SyntaxNode> NodeVisitEvent;
        public event Action NodeLeaveEvent;

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

        internal virtual void OnNodeEnterEvent()
        {
            NodeEnterEvent?.Invoke();
        }
        internal virtual void OnNodeVisitEvent(SyntaxNode value)
        {
            NodeVisitEvent?.Invoke(value);
        }
        internal virtual void OnNodeLeaveEvent()
        {
            NodeLeaveEvent?.Invoke();
        }
        internal virtual void InvokeEvents()
        {
            OnNodeEnterEvent();
            OnNodeVisitEvent(this);
            OnNodeLeaveEvent();
        }
        public virtual void Traverse() => SyntaxNodeVisitor.Visit(this);
    }
}
