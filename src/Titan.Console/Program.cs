using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Service;
using Titan.Service.Impl.HeuristicLab;

namespace Titan.Console
{
    class Program
    {
        public const string CancellationToken = "exit";
        private static readonly IEvaluationService EvaluationService = new EvaluationService();

        static void Main(string[] args)
        {
            string input;
            while (true)
            {
                input = System.Console.ReadLine();
                if (MatchCmd(input, CancellationToken)) break;

                EvaluationService.GenerateNetwork();

            }
        }

        static bool MatchCmd(string input, string cmd)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrEmpty(cmd)) return false;
            return string.Equals(input, cmd, StringComparison.OrdinalIgnoreCase);
        } 

    }
}
