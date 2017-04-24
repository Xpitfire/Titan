using System;

namespace Titan.Service.Communication
{
    public class ResponseMessage<T> : Message<T>
    {
        public ResponseType Type { get; set; }
    }

    [Serializable]
    public enum ResponseType
    {
        Successful,
        Failed
    }
}
