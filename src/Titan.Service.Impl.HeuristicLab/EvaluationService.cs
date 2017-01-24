using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;
using Titan.Service;

namespace Titan.Service.Impl.HeuristicLab
{
    public class EvaluationService : IEvaluationService
    {
        public double Evaluate(NetworkSyntax node)
        {
            return 0.0;
        }

        public string GraphDescription(NetworkSyntax node)
        {
            throw new NotImplementedException();
        }
    }
}
