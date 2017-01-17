using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Communication;
using Titan.Parser;

namespace Titan.Plugin.Communication
{
    public interface ICommunicationPlugin : ICommunication<ParsedMessage, string>, IPlugin
    {
    }
}
