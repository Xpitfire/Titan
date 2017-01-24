using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    public interface IVisitor<in TNode> where TNode : SyntaxNode
    {
        void Visit(TNode expression);
    }

    public interface IVisitor : IVisitor<SyntaxNode> { }
}
