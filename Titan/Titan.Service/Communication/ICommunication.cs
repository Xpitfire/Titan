using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Titan.Core.Graph;
using Titan.Model;

namespace Titan.Service.Communication
{
    public interface ICommunication<in TSendMessage, TReceiveMessage>
    {
        event MessageDelegate<string> JobCompletedEvent;

        Task<TReceiveMessage> PostAsync(TSendMessage message, string uriPath = null, IDictionary<string, string> headerParams = null);

        Task<TReceiveMessage> CreateClassificationModelAsync(Network model);

        Task<TReceiveMessage> LoginAsync(string username, string passwordHash = null);

        Task<TReceiveMessage> CreateClassificationDatasetAsync(Dataset dataset);

        Task<ResponseMessage<DatasetStatus>> GetJobStatusAsync(Dataset dataset);
    }

    [Serializable]
    public delegate void MessageDelegate<in TMessage>(TMessage message);
}
