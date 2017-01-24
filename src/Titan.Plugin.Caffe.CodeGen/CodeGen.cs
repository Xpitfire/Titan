using System;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Communication;
using Titan.Core.Syntax;
using Titan.Plugin.CodeGen;

namespace Titan.Plugin.Caffe.CodeGen
{
    public class CodeGen : MarshalByRefObject, ICodeGenPlugin
    {
        public const string CodeGenName = "Caffe";
        public event MessageDelegate<CodeGenMessage> CodeGeneratedEvent;
        
        public CodeGenMessage Generate(NetworkSyntax network)
        {
            if (network == null) return null;

            var solver = new CaffeScriptSolverTemplate
            {
                Network = network
            };
            var text = solver.TransformText();

            var message = new CodeGenMessage
            {
                Text = text,
                CodeGenName = CodeGenName
            };
            CodeGeneratedEvent?.Invoke(message);
            return message;
        }
        
    }
}
