using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Communication
{
    [Serializable]
    public class Message<T>
    {
        public T Data { get; set; }
    }
}
