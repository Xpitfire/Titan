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

        private InputLayerVertex() : this(null) { }
        public InputLayerVertex(string name) : this(name, InputLayerKind.Train) { }
        public InputLayerVertex(string name, InputLayerKind kind) : this(name, kind, DimensionData.Default) { }
        public InputLayerVertex(
            string name,
            InputLayerKind kind, 
            DimensionData dimensionData, 
            InputLayerParameter parameter = null,
            ImmutableList<VertexBase> outputLayers = null) : base(VertexKind.Input, name)
        {
            InputKind = kind;
            DimensionData = dimensionData;
            Parameter = parameter;
        }

        public InputLayerVertex AddData(DimensionData data)
        {
            var clone = this.DeepClone();
            clone.DimensionData = data;
            return clone;
        }

        public InputLayerVertex AddParameter(InputLayerParameter parameter)
        {
            var clone = this.DeepClone();
            clone.Parameter = parameter;
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
    public sealed class InputLayerParameter
    {
        public const int DefaultCropSize = 227;
        public const int DefaultBatchSize = 128;

        public int CropSize { get; internal set; }
        public bool Mirror { get; internal set; }
        public int BatchSize { get; internal set; }

        internal InputLayerParameter() { }
        internal InputLayerParameter(
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
