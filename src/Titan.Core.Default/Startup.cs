using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Default
{
    public sealed class Startup
    {

        public static void Initialize()
        {
            InstanceFactory.ParserInstance.MessageParsedEvent +=
                message => InstanceFactory.CommunicationInstance.SendAsync(message);
        }

    }
}
