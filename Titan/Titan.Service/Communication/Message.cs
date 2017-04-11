using System;

namespace Titan.Service.Communication
{
    [Serializable]
    public class Message<T>
    {
        public T Data { get; set; }
    }
}
