using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.AST
{
    [Serializable]
    public class NetworkRoot : INode
    {
        public string Name { get; set; }
        public INode Next { get; set; }

        public int Epochs { get; set; }
        public int ImageFormat { get; set; }
        public int ImageChannels { get; set; }
        public int BatchSize { get; set; }
        public int OutputLabels { get; set; }
        public string TrainDataPath { get; set; }
        public string ValDataPath { get; set; }
        public string OutputPath { get; set; }
        public int Seed { get; set; }
        public UpdaterType Updater { get; set; }
        public float LearningRate { get; set; }

        public List<INode> Layers { get; } = new List<INode>();
    }
}
