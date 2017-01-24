using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Service;

namespace Titan.HeuristicLab.Problem
{
    internal interface IEvaluator
    {
        void InitializeEvaluationTask(
            int threads = EvaluatorPresets.SingleThreaded);

        void InitializeEvaluationTask(
            string[] hosts = null,
            int threads = EvaluatorPresets.SingleThreaded);
    }

    public static class EvaluatorPresets
    {
        public const string LocalHost = "localhost";
        public const int SingleThreaded = 1;
        public static readonly string[] DefaultHosts = { LocalHost };
    }
}
