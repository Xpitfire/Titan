using System;

namespace Titan.Core.AST
{
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
}