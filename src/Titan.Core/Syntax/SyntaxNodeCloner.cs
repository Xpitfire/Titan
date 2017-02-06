using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    public static class SyntaxNodeCloner
    {
        public static TTarget Clone<TTarget>(this SyntaxNode node) => ObjectClone<SyntaxNode, TTarget>(node);
        
        public static TTarget ObjectClone<TSource, TTarget>(TSource source)
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

                if (source is NetworkSyntax && prop.Name == nameof(NetworkSyntax.Layers))
                {
                    var layers = (value as ImmutableList<LayerSyntax>);
                    if (layers != null)
                    {
                        var newLayers = new List<LayerSyntax>();
                        layers.ForEach(l => newLayers.Add(l.Clone<LayerSyntax>()));
                        value = newLayers.ToImmutableList();
                    }
                }
                else if (value is SyntaxNode)
                {
                    var methodType = typeof(SyntaxNodeCloner);
                    var method = methodType
                        .GetMethod(nameof(ObjectClone),
                            BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                        .MakeGenericMethod(value.GetType(), prop.PropertyType);
                    value = method.Invoke(null, new[] { value });
                }

                prop.SetValue(obj, value, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
            }

            return (TTarget)obj;
        }

        public static TTarget[] ArrayClone<TSource, TTarget>(TSource[] sourceArray)
        {
            if (sourceArray == null)
                return null;
            if (sourceArray.Length == 0)
                return new TTarget[0];

            var targetArray = new TTarget[sourceArray.Length];
            for (var i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = ObjectClone<TSource, TTarget>(sourceArray[i]);
            }

            return targetArray;
        }

        public static ImmutableList<TTarget> ListClone<TSource, TTarget>(ImmutableList<TSource> sourceList)
        {
            if (sourceList == null)
                return null;
            var targetList = new ImmutableList<TTarget>();
            foreach (var item in sourceList)
            {
                targetList.Add(ObjectClone<TSource, TTarget>(item));
            }
            return targetList;
        }

        public static ImmutableList<TTarget> ListClone<TSource, TTarget>(TSource[] sourceList)
            => sourceList == null ? null : ListClone<TSource, TTarget>(sourceList.ToImmutableList());
        public static TTarget[] ArrayClone<TSource, TTarget>(ImmutableList<TSource> sourceList)
            => sourceList == null ? null : ArrayClone<TSource, TTarget>(sourceList.ToArray());
    }
}
