using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.AST;
using Titan.Parser;
using Titan.Plugin.Parser;

namespace Titan.Plugin.Caffe.Parser
{
    public class Parser : MarshalByRefObject, IParserPlugin
    {
        public const string ParserName = "Caffe";
        public event MessageDelegate<ParsedMessage> MessageParsedEvent;

        public ParsedMessage Parse(INode root)
        {
            var network = root as NetworkRoot;
            if (network == null) return null;

            var solver = new CaffeScriptSolverTemplate
            {
                Network = network
            };

            var message = new ParsedMessage
            {
                Data = solver.TransformText(),
                ParserName = ParserName,
                ParseDate = DateTime.Now
            };
            MessageParsedEvent?.Invoke(message);
            return message;
        }

        public Task<ParsedMessage> ParseAsync(INode root)
        {
            return Task.Run(() => Parse(root));
        }
        
    }
}
