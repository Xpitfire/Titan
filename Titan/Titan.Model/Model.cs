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
        public const int DefaultEpochSize = 100;
        public const UpdaterType DefaultUpdaterType = UpdaterType.StochasticGradientDescent;
        public const float DefaultLearningRate = 0.003f;
        public const int DefaultBatchSize = 50;
        public const int DefaultSeedValue = 0; // random seed

        public string Id { get; set; }
        public string Name { get; set; }
        public string DatasetId { get; set; }
        public string Network { get; set; }

        public bool UseGpu { get; set; }
        public int GpuCount { get; set; }
        public int Epochs { get; set; } = DefaultEpochSize;
        public int BatchSize { get; set; } = DefaultBatchSize;
        public int Seed { get; set; } = DefaultSeedValue;
        public UpdaterType Updater { get; set; } = DefaultUpdaterType;
        public float LearningRate { get; set; } = DefaultLearningRate;
    }
}

[Serializable]
public enum UpdaterType
{
    StochasticGradientDescent,
    Adam,
    AdaDelta,
    Nesterov,
    Adagrad,
    RmsProp
}