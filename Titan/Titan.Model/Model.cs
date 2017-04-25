using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph;

namespace Titan.Model
{
    public class Model
    {
        public Network Network { get; set; }
        public string Name { get; set; }
        public Dataset Dataset { get; set; }
    }
}
