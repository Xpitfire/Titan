using System;
using System.Collections.Generic;
using Titan.Core.Collection;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class ConvolutionalLayerVertex : LayerVertex, IOperationalLayer
    {
        public ConvolutionalLayerParameter Parameter { get; internal set; }
        public ImmutableList<ConvolutionalLayerLearningRateParameter> LearnRateParameters { get; internal set; }

        internal ConvolutionalLayerVertex() : this(null) { }
        internal ConvolutionalLayerVertex(string name) : base(VertexKind.Convolutional, name) { }
        internal ConvolutionalLayerVertex(string name, 
            ConvolutionalLayerParameter parameter,
            ImmutableList<ConvolutionalLayerLearningRateParameter> learnRateParams = null) : this(name)
        {
            Parameter = parameter;
            LearnRateParameters = learnRateParams;
        }

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(Parameter.NumberOfOutput)] = Parameter.NumberOfOutput;
            props[nameof(Parameter.KernelSize)] = Parameter.KernelSize;
            props[nameof(Parameter.Padding)] = Parameter.Padding;
            props[nameof(Parameter.Stride)] = Parameter.Stride;
            props[nameof(Parameter.BiasTerm)] = Parameter.BiasTerm;
            return props;
        }

        internal override LayerVertex Deserialize(IReadOnlyDictionary<string, object> properties)
        {
            base.Deserialize(properties);
            var parameter = new ConvolutionalLayerParameter();
            int.TryParse(properties[nameof(Parameter.NumberOfOutput)].ToString(), out int numberOfOutput);
            parameter.NumberOfOutput = numberOfOutput;
            int.TryParse(properties[nameof(Parameter.KernelSize)].ToString(), out int kernelSize);
            parameter.KernelSize = kernelSize;
            int.TryParse(properties[nameof(Parameter.Padding)].ToString(), out int padding);
            parameter.Padding = padding;
            int.TryParse(properties[nameof(Parameter.Stride)].ToString(), out int stride);
            parameter.Stride = stride;
            bool.TryParse(properties[nameof(Parameter.BiasTerm)].ToString(), out bool biasTerm);
            parameter.BiasTerm = biasTerm;
            return this;
        }
    }

    [Serializable]
    public sealed class ConvolutionalLayerLearningRateParameter
    {
        public int LearningRateMultiplication { get; internal set; }
        public int DecayMultiplication { get; internal set; }

        public ConvolutionalLayerLearningRateParameter(
            int learningRateMultiplication,
            int decayMultiplication)
        {
            LearningRateMultiplication = learningRateMultiplication;
            DecayMultiplication = decayMultiplication;
        }
    }

    [Serializable]
    public sealed class ConvolutionalLayerWeightFillerParameter
    {
        public ConvolutionalLayerWeightFillerKind WeightFillerKind { get; internal set; }

        public ConvolutionalLayerWeightFillerParameter(
            ConvolutionalLayerWeightFillerKind kind = ConvolutionalLayerWeightFillerKind.Xavier)
        {
            WeightFillerKind = kind;
        }
    }

    [Serializable]
    public enum ConvolutionalLayerWeightFillerKind
    {
        Xavier
    }

    [Serializable]
    public sealed class ConvolutionalLayerBiasFillerParameter
    {
        public ConvolutionalLayerBiasFillerKind BiasFillerKind { get; internal set; }
        public float Value { get; internal set; }

        public ConvolutionalLayerBiasFillerParameter(
            ConvolutionalLayerBiasFillerKind kind,
            float value)
        {
            BiasFillerKind = kind;
            Value = value;
        }
    }

    [Serializable]
    public enum ConvolutionalLayerBiasFillerKind
    {
        Constant
    }

    [Serializable]
    public sealed class ConvolutionalLayerParameter
    {
        public int NumberOfOutput { get; internal set; }
        public int KernelSize { get; internal set; }
        public int Padding { get; internal set; }
        public int Stride { get; internal set; }
        public bool BiasTerm { get; internal set; }

        internal ConvolutionalLayerParameter() { }
        internal ConvolutionalLayerParameter(
            int numberOfOutput, 
            int kernelSize, 
            int padding, 
            int stride,
            bool biasTerm = false)
        {
            NumberOfOutput = numberOfOutput;
            KernelSize = kernelSize;
            Padding = padding;
            Stride = stride;
            BiasTerm = biasTerm;
        }
    }

}
