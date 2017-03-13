using System;
using Titan.Core.Collection;

namespace Titan.Core.Graph.Vertex
{
    [Serializable]
    public sealed class InputLayerVertex : LayerVertex
    {
        public DimensionData DimensionData { get; internal set; }
        public InputLayerKind InputKind { get; internal set; }
        public InputLayerParameter Parameter { get; internal set; }

        internal InputLayerVertex() : this(null) { }
        internal InputLayerVertex(string name) : base(VertexKind.Input, name) { }
        
    }

    [Serializable]
    public sealed class DimensionData
    {
        public static readonly DimensionData Default = new DimensionData();

        public const int DefaultHeightDimension = 224;
        public const int DefaultWidthDimension = 224;
        public const int DefaultChannelsDimension = 3;

        public int Height { get; internal set; }
        public int Width { get; internal set; }
        public int Channels { get; internal set; }

        internal DimensionData() { }
        
    }
    
    [Serializable]
    public sealed class InputLayerParameter
    {
        public const int DefaultCropSize = 227;
        public const int DefaultBatchSize = 128;

        public int CropSize { get; internal set; }
        public bool Mirror { get; internal set; }
        public int BatchSize { get; internal set; }

        internal InputLayerParameter() { }
    }

    [Serializable]
    public enum InputLayerKind
    {
        Train,
        Validation,
        Test
    }
}
