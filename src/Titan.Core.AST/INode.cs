using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.AST
{
    public interface INode
    {
        string Name { get; set; }
        INode Next { get; set; }
    }
}
