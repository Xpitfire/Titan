using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InputLayerSyntax : LayerSyntax
    {
        public static readonly InputMatrix DefaultInputMatrix = new InputMatrix(224, 224, 3);

        public InputMatrix Data { get; internal set; }

        internal InputLayerSyntax() : this(DefaultInputMatrix) { }
        internal InputLayerSyntax(InputMatrix data) : base(SyntaxKind.Input)
        {
            Data = data;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public struct InputMatrix
    {
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
}
