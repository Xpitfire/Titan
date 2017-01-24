using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Communication;
using Titan.Core.Syntax;
using Titan.Plugin.CodeGen;

namespace Titan.Plugin.GraphViz.CodeGen
{
    public class CodeGen : MarshalByRefObject, ICodeGenPlugin
    {
        public const string CodeGenName = "GraphViz";
        public event MessageDelegate<CodeGenMessage> CodeGeneratedEvent;
        public CodeGenMessage GenerateAsync(NetworkSyntax network)
        {
            var message = new CodeGenMessage
            {
                Text = "test",
                CodeGenName = CodeGenName
            };
            CodeGeneratedEvent?.Invoke(message);
            return message;
        }

        [Serializable]
        public class TestVisitor : IVisitor
        {
            public void Visit(SyntaxNode expression)
            {
                Console.WriteLine($"CodeGen: {expression.Spix}");
            }
        }
        
    }
}
