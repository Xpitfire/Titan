using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Immutable
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
