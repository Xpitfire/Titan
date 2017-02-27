using System;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InputLayerSyntax : SyntaxNode
    {
        public DimensionData DimensionData { get; internal set; }
        public LabelData LabelData { get; internal set; }
        public InputLayerKind InputKind { get; internal set; }
        public InputLayerParameterSyntax Parameter { get; internal set; }
        public ImmutableList<SyntaxNode> OutputLayers { get; internal set; }

        private InputLayerSyntax() : base() { }
        internal InputLayerSyntax(string name, InputLayerKind kind) : this(name, kind, DimensionData.Default, LabelData.Empty) { }
        internal InputLayerSyntax(
            string name,
            InputLayerKind kind, 
            DimensionData dimensionData, 
            LabelData labelData, 
            InputLayerParameterSyntax parameter = null,
            ImmutableList<SyntaxNode> outputLayers = null) : base(name)
        {
            InputKind = kind;
            DimensionData = dimensionData;
            LabelData = labelData;
            Parameter = parameter;
            OutputLayers = outputLayers;
        }

        public InputLayerSyntax AddData(DimensionData data)
        {
            var clone = this.DeepClone();
            clone.DimensionData = data;
            return clone;
        }

        public InputLayerSyntax AddLabel(LabelData labelData)
        {
            var clone = this.DeepClone();
            clone.LabelData = labelData;
            return clone;
        }

        public InputLayerSyntax AddParameter(InputLayerParameterSyntax parameter)
        {
            var clone = this.DeepClone();
            clone.Parameter = parameter;
            return clone;
        }

        public InputLayerSyntax AddOutputLayers(ImmutableList<SyntaxNode> outputLayers)
        {
            var clone = this.DeepClone();
            clone.OutputLayers = outputLayers;
            return clone;
        }
        
    }

    [Serializable]
    public struct DimensionData
    {
        public static readonly DimensionData Default = new DimensionData();

        public const int DefaultHeightDimension = 224;
        public const int DefaultWidthDimension = 224;
        public const int DefaultChannelsDimension = 3;

        public int Height { get; internal set; }
        public int Width { get; internal set; }
        public int Channels { get; internal set; }
        
        public DimensionData(int height = DefaultHeightDimension, 
            int width = DefaultWidthDimension, 
            int channels = DefaultChannelsDimension)
        {
            Height = height;
            Width = width;
            Channels = channels;
        }
    }

    [Serializable]
    public struct LabelData
    {
        public static readonly LabelData Empty = new LabelData(0);
        public int Length { get; internal set; }

        public LabelData(int length)
        {
            Length = length;
        }
    }

    [Serializable]
    public sealed class InputLayerParameterSyntax : SyntaxNode
    {
        public const int DefaultCropSize = 227;
        public const int DefaultBatchSize = 128;

        public int CropSize { get; internal set; }
        public bool Mirror { get; internal set; }
        public int BatchSize { get; internal set; }

        internal InputLayerParameterSyntax() { }
        internal InputLayerParameterSyntax(
            int cropSize = DefaultCropSize,
            int batchSize = DefaultBatchSize,
            bool mirror = false)
        {
            CropSize = cropSize;
            BatchSize = batchSize;
            Mirror = mirror;
        }
    }

    [Serializable]
    public enum InputLayerKind
    {
        Train,
        Validation,
        Test
    }
}
