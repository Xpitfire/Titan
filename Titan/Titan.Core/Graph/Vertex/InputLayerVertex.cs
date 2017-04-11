using System;
using System.Collections.Generic;
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

        public override IDictionary<string, object> Serialize()
        {
            var props = base.Serialize();
            props[nameof(DimensionData.Channels)] = DimensionData.Channels;
            props[nameof(DimensionData.Height)] = DimensionData.Height;
            props[nameof(DimensionData.Width)] = DimensionData.Width;
            props[nameof(InputKind)] = InputKind.ToString();
            props[nameof(Parameter.BatchSize)] = Parameter.BatchSize;
            props[nameof(Parameter.CropSize)] = Parameter.CropSize;
            props[nameof(Parameter.Mirror)] = Parameter.Mirror;
            return props;
        }
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
