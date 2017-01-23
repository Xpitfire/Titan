using System;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Core.CodeGen;
using Titan.Core.Syntax.Type;
using Titan.Plugin.Caffe.Parser;
using Titan.Plugin.CodeGen;

namespace Titan.Plugin.Caffe.CodeGen
{
    public class CodeGen : MarshalByRefObject, ICodeGenPlugin
    {
        public const string CodeGenName = "Caffe";
        public event MessageDelegate<CodeGenMessage> CodeGeneratedEvent;
        
        public Task<CodeGenMessage> GenerateAsync(NetworkSyntax network)
        {
            return Task.Run(() =>
            {
                if (network == null) return null;

                var solver = new CaffeScriptSolverTemplate
                {
                    Network = network
                };

                var message = new CodeGenMessage
                {
                    Text = solver.TransformText(),
                    Data = network,
                    CodeGenName = CodeGenName,
                    CodeGenDate = DateTime.Now
                };
                CodeGeneratedEvent?.Invoke(message);
                return message;
            });
        }
        
    }
}
