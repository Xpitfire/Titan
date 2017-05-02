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
        public string Id { get; set; }
        public string Name { get; set; }
        public string DatasetId { get; set; }
        public string Network { get; set; }

        public bool UseGpu { get; set; }
        public int GpuCount { get; set; }
    }
}
