using System;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class InputLayerSyntax : LayerSyntax
    {
        public new static event VisitorDelegate<InputLayerSyntax> VisitedEvent;

        public InputMatrix Data { get; internal set; }

        private InputLayerSyntax() : this(InputMatrix.DefaultInputMatrix) { }
        internal InputLayerSyntax(string name) : this(InputMatrix.DefaultInputMatrix, name) { }
        internal InputLayerSyntax(InputMatrix data, string name = null) : base(SyntaxKind.Input)
        {
            Data = data;
            Name = name;
        }

        internal override void Traverse() => VisitedEvent?.Invoke(this);
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
}
