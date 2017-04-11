using Titan.Core.Parser;

namespace Titan.Service.Parser
{
    public interface IParserPlugin : IParser<ParserMessage>, IPlugin
    {
    }
}
