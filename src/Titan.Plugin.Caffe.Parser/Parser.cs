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
        public Parser() : base() { }

        public ParsedMessage Parse(INode root)
        {
            Console.WriteLine("Parser loaded!");
            return new ParsedMessage
            {
                MessageText = "test message",
                ParserName = "Caffe Parser",
                ParseDate = DateTime.Now
            };
        }
    }
}
