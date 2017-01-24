using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Service
{
    public interface IEvaluationService
    {
        double Evaluate(NetworkSyntax node);
        string GraphDescription(NetworkSyntax node);
        NetworkSyntax GenerateNetwork();
    }
}
