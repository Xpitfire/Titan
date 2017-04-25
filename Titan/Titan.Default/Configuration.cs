namespace Titan.Default
{
    public sealed class Configuration
    {
        public static void Initialize()
        {
            InstanceFactory.ParserInstance.MessageParsedEvent +=
                message => InstanceFactory.CodeGenInstance.Generate(message.Network);
            InstanceFactory.CodeGenInstance.CodeGeneratedEvent +=
                message => InstanceFactory.CommunicationInstance.CreateClassificationModelAsync(
                    new Model.Model
                    {
                        Network = message.Data
                    });
        }
    }
}
