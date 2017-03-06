using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Titan.Core.Collection;

namespace Titan.Core.Graph.Vertex
{
    public static class VertexCloner
    {
        public static TTarget DeepClone<TTarget>(this TTarget source) where TTarget : IVertex
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Position = 0;
                return (TTarget)formatter.Deserialize(stream);
            }
        }

        public static TTarget ShallowClone<TTarget>(this TTarget source) where TTarget : IVertex
        {
            if (source == null)
                return default(TTarget);

            var targetType = typeof(TTarget);
            var targetProps = targetType.GetProperties();
            var obj = Activator.CreateInstance(source.GetType(), true);
            var sourceProps = source.GetType().GetProperties();
            var sourcePropsNames = new string[sourceProps.Length];
            for (var i = 0; i < sourceProps.Length; i++)
                sourcePropsNames[i] = sourceProps[i].Name;

            foreach (var prop in targetProps)
            {
                if (!sourcePropsNames.Contains(prop.Name)) continue;
                if (prop.GetSetMethod(true) == null) continue;

                var value = source
                    .GetType()
                    .GetProperty(prop.Name)?
                    .GetValue(source);
                if (value == null) continue;
                if (value is IVertex) continue;
                
                prop.SetValue(obj, value, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
            }

            return (TTarget)obj;
        }

        public static TTarget[] ArrayClone<TTarget>(TTarget[] sourceArray) where TTarget : IVertex
        {
            if (sourceArray == null)
                return null;
            if (sourceArray.Length == 0)
                return new TTarget[0];

            var targetArray = new TTarget[sourceArray.Length];
            for (var i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = DeepClone(sourceArray[i]);
            }

            return targetArray;
        }

        public static ImmutableList<TTarget> ListClone<TTarget>(ImmutableList<TTarget> sourceList) where TTarget : IVertex
        {
            if (sourceList == null)
                return null;
            var targetList = new List<TTarget>();
            foreach (var item in sourceList)
            {
                targetList.Add(DeepClone(item));
            }
            return targetList.ToImmutableList();
        }

        public static ImmutableList<TTarget> ListClone<TTarget>(TTarget[] sourceList) where TTarget : IVertex
            => sourceList == null ? null : ListClone(sourceList.ToImmutableList());
        public static TTarget[] ArrayClone<TTarget>(ImmutableList<TTarget> sourceList) where TTarget : IVertex
            => sourceList == null ? null : ArrayClone(sourceList.ToArray());
    }
}
