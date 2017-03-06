﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Communication;
using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;

namespace Titan.Core.CodeGen
{
    public interface ICodeGen<out TMessage> where TMessage : CodeGenMessage
    {
        event MessageDelegate<TMessage> CodeGeneratedEvent;

        TMessage Generate(Network network);
    }
}
