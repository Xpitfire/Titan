using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Service.Communication;
using Titan.Service.Parser;

namespace Titan.Plugin.Caffe.Parser
{
    public partial class Parser : IParserPlugin
    {
        public const string ParserName = "Caffe";

        public Dictionary<string, dynamic> Properties { get; private set; }

        public event MessageDelegate<ParserMessage> MessageParsedEvent;
        public ParserMessage Parse(string source)
        {
            ParseCaffePrototxt(source);
            var converter = new CaffeConverter(Properties);
            converter.TransformToNetwork();
            var message = new ParserMessage
            {
                Network = converter.Network,
                Data = source,
                ParseDate = DateTime.Now,
                ParserName = ParserName
            };
            MessageParsedEvent?.Invoke(message);
            return message;
        }

        public void ParseCaffePrototxt(string source)
        {
            var scanner = new Scanner(source);
            this.Initialize(scanner);
            this.Run();
            if (errors.count > 0)
            {
                throw new InvalidOperationException("Could not parse prototxt file!");
            }
        }
    }
}