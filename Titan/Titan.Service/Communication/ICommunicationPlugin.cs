using Titan.Core.Communication;

namespace Titan.Service.Communication
{
    public interface ICommunicationPlugin : ICommunication<string, string>, IPlugin
    {
    }
}
