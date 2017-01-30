using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InputLayerSyntax : LayerSyntax
    {
        public Data Data { get; internal set; }
        public Label Label { get; internal set; }
        public InputLayerType Type { get; internal set; }
        public InputLayerParameterSyntax Parameter { get; internal set; }

        private InputLayerSyntax() : base(SyntaxKind.Input) { }
        internal InputLayerSyntax(InputLayerType type, string name) : this(type, Data.Empty, Label.Empty, null, name) { }
        internal InputLayerSyntax(
            InputLayerType type, 
            Data data, 
            Label label, 
            InputLayerParameterSyntax parameter = null,
            string name = null) : base(SyntaxKind.Input)
        {
            Type = type;
            Data = data;
            Label = label;
            Parameter = parameter;
            Name = name;
        }
        
        public LayerSyntax AddData(Data data)
        {
            var clone = this.Clone<InputLayerSyntax>();
            clone.Data = data;
            return clone;
        }

        public LayerSyntax AddLabel(Label label)
        {
            var clone = this.Clone<InputLayerSyntax>();
            clone.Label = label;
            return clone;
        }

        public LayerSyntax AddParameter(InputLayerParameterSyntax parameter)
        {
            var clone = this.Clone<InputLayerSyntax>();
            clone.Parameter = parameter;
            return clone;
        }
        
    }

    [Serializable]
    public struct Data
    {
        public static readonly Data Empty = new Data();

        public const int DefaultHeightDimension = 224;
        public const int DefaultWidthDimension = 224;
        public const int DefaultChannelsDimension = 3;

        public int Height { get; internal set; }
        public int Width { get; internal set; }
        public int Channels { get; internal set; }

        public ImmutableList<float[]> DataVector { get; internal set; }
        
        public Data(ImmutableList<float[]> dataVector, 
            int height = DefaultHeightDimension, 
            int width = DefaultWidthDimension, 
            int channels = DefaultChannelsDimension)
        {
            Height = height;
            Width = width;
            Channels = channels;
            DataVector = dataVector;
        }
    }

    [Serializable]
    public struct Label
    {
        public static readonly Label Empty = new Label();
        public ImmutableList<string> LabelVector { get; internal set; }

        public Label(ImmutableList<string> labelVector)
        {
            LabelVector = labelVector;
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
    public enum InputLayerType
    {
        Train,
        Validation,
        Test
    }
}
