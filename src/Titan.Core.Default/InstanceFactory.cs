using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Communication;
using Titan.Core.Parser;
using Titan.Plugin.CodeGen;
using Titan.Plugin.Communication;
using Titan.Plugin.Parser;

namespace Titan.Core.Default
{
    public sealed class InstanceFactory
    {
        private static ICommunication<string, string> _communicationInstance;
        public static ICommunication<string, string> CommunicationInstance => 
            _communicationInstance ?? (_communicationInstance = PluginFactory.Get<ICommunicationPlugin>());

        private static IParser<ParserMessage> _parserInstance;
        public static IParser<ParserMessage> ParserInstance => 
            _parserInstance ?? (_parserInstance = PluginFactory.Get<IParserPlugin>());

        private static ICodeGen<CodeGenMessage> _codeGenInstance;
        public static ICodeGen<CodeGenMessage> CodeGenInstance =>
            _codeGenInstance ?? (_codeGenInstance = PluginFactory.Get<ICodeGenPlugin>());
    }
}
