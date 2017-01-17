using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Parser;
using Titan.Plugin.Communication;
using Titan.Plugin.Parser;

namespace Titan.Core.Default
{
    public sealed class InstanceFactory
    {
        public static ICommunication<ParsedMessage, string> CommunicationInstance => PluginFactory.Get<ICommunicationPlugin>();
        public static IParser<ParsedMessage> ParserInstance => PluginFactory.Get<IParserPlugin>();
    }
}
