using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InputLayerSyntax : LayerSyntax
    { 
        public InputMatrix Data { get; internal set; }
        public InputLayerType Type { get; internal set; }

        private InputLayerSyntax() : base(SyntaxKind.Input) { }
        internal InputLayerSyntax(InputLayerType type, string name) : this(type, InputMatrix.DefaultInputMatrix, name) { }
        internal InputLayerSyntax(InputLayerType type, InputMatrix data, string name = null) : base(SyntaxKind.Input)
        {
            Type = type;
            Data = data;
            Name = name;
        }

        public override LayerSyntax AddNextLayer(LayerSyntax layer)
        {
            var clone = this.Clone<InputLayerSyntax>();
            clone.NextLayer = layer;
            return clone;
        }
    }

    [Serializable]
    public struct InputMatrix
    {
        public static readonly InputMatrix DefaultInputMatrix = new InputMatrix(224, 224, 3);

        public int Height { get; internal set; }
        public int Width { get; internal set; }
        public int Channels { get; internal set; }

        public InputMatrix(int height, int width, int channels)
        {
            Height = height;
            Width = width;
            Channels = channels;
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
