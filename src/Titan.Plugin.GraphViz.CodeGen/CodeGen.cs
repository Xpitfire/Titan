﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.CodeGen;
using Titan.Core.Communication;
using Titan.Core.Prefab;
using Titan.Core.Syntax;
using Titan.Plugin.CodeGen;

namespace Titan.Plugin.GraphViz.CodeGen
{
    public class CodeGen : MarshalByRefObject, ICodeGenPlugin
    {
        public const string CodeGenName = "GraphViz";
        public event MessageDelegate<CodeGenMessage> CodeGeneratedEvent;
        public CodeGen()
        {
            SyntaxNodeVisitor.Register(Assembly.GetExecutingAssembly());
        }

        public CodeGenMessage Generate(NetworkSyntax network)
        {
            string code = CodeGenWriter.Build(network);
            var message = new CodeGenMessage
            {
                Text = code,
                CodeGenName = CodeGenName
            };
            CodeGeneratedEvent?.Invoke(message);
            return message;
        }
    }
}
