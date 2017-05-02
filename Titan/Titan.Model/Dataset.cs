using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model
{
    public class Dataset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TrainPath { get; set; }
        public string TestPath { get; set; }

        public string Encoding { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Channels { get; set; }
    }
}
