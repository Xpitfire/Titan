using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Communication;
using Titan.Core.Parser;
using Titan.Core.Syntax;
using Titan.Plugin.Parser;

namespace Titan.Plugin.Caffe.Parser
{
    public class Parser : MarshalByRefObject, IParserPlugin
    {
        public const string ParserName = "Caffe";

        public event MessageDelegate<ParserMessage> MessageParsedEvent;
        public ParserMessage ParseAsync(string source)
        {
            var message = new ParserMessage
            {
                // TODO: Perform real syntax tree definition
                SyntaxTree = SyntaxFactory.Network(),
                Data = source,
                ParseDate = DateTime.Now,
                ParserName = ParserName
            };
            MessageParsedEvent?.Invoke(message);
            return message;
        }
    }
}
