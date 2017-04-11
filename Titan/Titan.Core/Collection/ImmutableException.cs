using System;
using System.Runtime.Serialization;

namespace Titan.Core.Collection
{

    [Serializable]
    internal class ImmutableException : Exception
    {
        public ImmutableException() : this("Object instance cannot be modified!")
        {
        }

        public ImmutableException(string message) : base(message)
        {
        }

        public ImmutableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImmutableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
