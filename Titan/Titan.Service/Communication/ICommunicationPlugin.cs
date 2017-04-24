using Titan.Service.CodeGen;

namespace Titan.Service.Communication
{
    public interface ICommunicationPlugin : ICommunication<string, ResponseMessage<string>>, IPlugin
    {
    }
}
