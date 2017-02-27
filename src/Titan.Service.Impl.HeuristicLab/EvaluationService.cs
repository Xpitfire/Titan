using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Default;
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
            return InstanceFactory.CodeGenInstance.Generate(node).Text;
        }

        public NetworkSyntax GenerateNetwork()
        {
            var networkParam = SyntaxFactory.NetworkParameter();
            var network = SyntaxFactory
                .Network("Demo", networkParam)
                .AddLayer(SyntaxFactory.ConvolutionalLayer("conv1", "train"));
            return network;
        }
    }
}
