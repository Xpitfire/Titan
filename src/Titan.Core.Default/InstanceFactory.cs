using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.CodeGen;
using Titan.Core.Parser;
using Titan.Plugin.CodeGen;
using Titan.Plugin.Communication;
using Titan.Plugin.Parser;

namespace Titan.Core.Default
{
    public sealed class InstanceFactory
    {
        private static ICommunication<string, string> communicationInstance;
        public static ICommunication<string, string> CommunicationInstance => 
            communicationInstance ?? (communicationInstance = PluginFactory.Get<ICommunicationPlugin>());

        private static IParser<ParserMessage> parserInstance;
        public static IParser<ParserMessage> ParserInstance => 
            parserInstance ?? (parserInstance = PluginFactory.Get<IParserPlugin>());

        private static ICodeGen<CodeGenMessage> codeGenInstance;
        public static ICodeGen<CodeGenMessage> CodeGenInstance =>
            codeGenInstance ?? (codeGenInstance = PluginFactory.Get<ICodeGenPlugin>());
    }
}
