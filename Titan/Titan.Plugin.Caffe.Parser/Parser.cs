using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph;
using Titan.Service.Communication;
using Titan.Service.Parser;

namespace Titan.Plugin.Caffe.Parser
{
    public partial class Parser : IParserPlugin
    {
        public const string ParserName = "Caffe";

        public Dictionary<string, dynamic> Properties { get; private set; }
        public Network Network { get; private set; }

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
            ParseCaffePrototxt(source);
            TransformToNetwork();
            return null;
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

        public void TransformToNetwork()
        {
            // TODO
        }
        
        void InsertValue(string key, dynamic value, Dictionary<string, dynamic> dict)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else if (dict.ContainsKey(key)
                && dict[key] as List<dynamic> != null)
            {
                dict[key].Add(value);
            }
            else
            {
                var values = new List<dynamic>
                {
                    dict[key]
                };
                dict[key] = values;
            }
        }
    }
}