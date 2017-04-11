using System;

namespace Titan.Core.Communication
{
    [Serializable]
    public class Message<T>
    {
        public T Data { get; set; }
    }
}
