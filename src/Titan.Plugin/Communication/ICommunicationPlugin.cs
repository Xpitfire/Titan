using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Communication;
using Titan.Core.Parser;

namespace Titan.Plugin.Communication
{
    public interface ICommunicationPlugin : ICommunication<string, string>, IPlugin
    {
    }
}
