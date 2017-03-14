using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;
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
        }

        private static void FormatVertex(object sender, FormatVertexEventArgs<LayerVertex> e)
        {
            var ent = e.Vertex;
            var rec = new GraphvizRecord();
            rec.Cells.Add(new GraphvizRecordCell
            {
                Text = ent.Name,
                Port = ent.Name
            });
            e.VertexFormatter.Record = rec;
            e.VertexFormatter.Label = ent.Name;
        }
        
        static bool MatchCmd(string input, string cmd)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrEmpty(cmd)) return false;
            return string.Equals(input, cmd, StringComparison.OrdinalIgnoreCase);
        } 

    }
}
