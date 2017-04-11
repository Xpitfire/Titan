using System;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Communication;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;
using Titan.Service.CodeGen;

namespace Titan.Plugin.Caffe.CodeGen
{
    public class CodeGen : ICodeGenPlugin
    {
        public const string CodeGenName = "Caffe";
        public event MessageDelegate<CodeGenMessage> CodeGeneratedEvent;
        
        public CodeGenMessage Generate(Network network)
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
