﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Parser;

namespace Titan.Plugin.Parser
{
    public interface IParserPlugin : IParser<ParserMessage>, IPlugin
    {
    }
}
