using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model
{
    public class InvalidJobException : Exception
    {
        public InvalidJobException()
        {
        }

        public InvalidJobException(string message) : base(message)
        {
        }

        public InvalidJobException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidJobException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
