using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;

namespace Titan.Service
{
    public interface IEvaluationService
    {
        double Evaluate(Network node);
        string GraphDescription(Network node);
        Network GenerateNetwork();
    }
}
