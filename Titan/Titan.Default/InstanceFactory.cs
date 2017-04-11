using Titan.Core.CodeGen;
using Titan.Core.Communication;
using Titan.Core.Parser;
using Titan.Service.CodeGen;
using Titan.Service.Communication;
using Titan.Service.Parser;

namespace Titan.Default
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
