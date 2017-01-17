using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.AST;
using Titan.Parser;
using Titan.Plugin.Parser;

namespace Titan.Plugin.Caffe.Parser
{
    public class Parser : MarshalByRefObject, IParserPlugin
    {
        public ParsedMessage Parse(INode root)
        {
            var network = root as NetworkRoot;
            if (network == null) return null;

            var solver = new CaffeScriptSolverTemplate
            {
                Network = network
            };
            
            return new ParsedMessage
            {
                MessageText = solver.TransformText(),
                ParserName = "Caffe Parser",
                ParseDate = DateTime.Now
            };
        }
    }
}
