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
        public event MessageDelegate<ParsedMessage> MessageParsedEvent;

        public ParsedMessage Parse(INode root)
        {
            return BuildMessage(root);
        }

        public Task<ParsedMessage> ParseAsync(INode root)
        {
            return Task.Run(() => BuildMessage(root));
        }

        private ParsedMessage BuildMessage(INode root)
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
                ParserName = "Caffe Parser",
                ParseDate = DateTime.Now
            };
            MessageParsedEvent?.Invoke(message);
            return message;
        }
    }
}
