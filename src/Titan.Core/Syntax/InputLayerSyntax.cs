using System;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InputLayerSyntax : SyntaxNode
    {
        public Dimension Dimension { get; internal set; }
        public Label Label { get; internal set; }
        public InputLayerKind InputKind { get; internal set; }
        public InputLayerParameterSyntax Parameter { get; internal set; }

        private InputLayerSyntax() : base() { }
        internal InputLayerSyntax(InputLayerKind kind, string name = null) : this(kind, Dimension.Default, Label.Empty, null, name) { }
        internal InputLayerSyntax(
            InputLayerKind kind, 
            Dimension dimension, 
            Label label, 
            InputLayerParameterSyntax parameter = null,
            string name = null) : base(name)
        {
            InputKind = kind;
            Dimension = dimension;
            Label = label;
            Parameter = parameter;
        }
        
        public InputLayerSyntax AddData(Dimension data)
        {
            var clone = this.DeepClone();
            clone.Dimension = data;
            return clone;
        }

        public InputLayerSyntax AddLabel(Label label)
        {
            var clone = this.DeepClone();
            clone.Label = label;
            return clone;
        }

        public InputLayerSyntax AddParameter(InputLayerParameterSyntax parameter)
        {
            var clone = this.DeepClone();
            clone.Parameter = parameter;
            return clone;
        }
        
    }

    [Serializable]
    public struct Dimension
    {
        public static readonly Dimension Default = new Dimension();

        public const int DefaultHeightDimension = 224;
        public const int DefaultWidthDimension = 224;
        public const int DefaultChannelsDimension = 3;

        public int Height { get; internal set; }
        public int Width { get; internal set; }
        public int Channels { get; internal set; }
        
        public Dimension(int height = DefaultHeightDimension, 
            int width = DefaultWidthDimension, 
            int channels = DefaultChannelsDimension)
        {
            Height = height;
            Width = width;
            Channels = channels;
        }
    }

    [Serializable]
    public struct Label
    {
        public static readonly Label Empty = new Label(0);
        public int Length { get; internal set; }

        public Label(int length)
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
