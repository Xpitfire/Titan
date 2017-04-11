﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph;
using Titan.Service.Communication;
using Titan.Service.Parser;

namespace Titan.Plugin.Caffe.Parser
{
    public class Parser : IParserPlugin
    {
        public const string ParserName = "Caffe";

        public event MessageDelegate<ParserMessage> MessageParsedEvent;
        public ParserMessage Parse(string source)
        {
            //var message = new ParserMessage
            //{
            //    // TODO: Perform real syntax tree definition
            //    Network = SyntaxFactory.Network("CaffeDemo"),
            //    Data = source,
            //    ParseDate = DateTime.Now,
            //    ParserName = ParserName
            //};
            //MessageParsedEvent?.Invoke(message);
            //return message;
            return null;
        }
    }
}
