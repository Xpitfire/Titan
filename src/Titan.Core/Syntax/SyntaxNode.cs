using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public delegate void VisitorDelegate<in TNode>(TNode node) where TNode : SyntaxNode;

    [Serializable]
    public abstract class SyntaxNode
    {
        public Spix Spix { get; internal set; }
        private string _name;
        public string Name {
            get { return _name ?? Spix.Id; }
            internal set { _name = value; }
        }

        protected SyntaxNode() : this(new Spix()) { }
        protected SyntaxNode(string name = null) : this(new Spix(name)) { }
        protected SyntaxNode(Spix spix, string name = null)
        {
            Spix = spix;
            if (name != null)
            {
                Name = name;
            }
        }
    }

    public static class SyntaxNodeExtension
    {
        public static TTarget Clone<TTarget>(this SyntaxNode node) => ObjectClone<SyntaxNode, TTarget>(node);

        public static TTarget ObjectClone<TSource, TTarget>(TSource source)
        {
            if (source == null)
                return default(TTarget);

            var targetType = typeof(TTarget);
            var targetProps = targetType.GetProperties();
            var obj = Activator.CreateInstance(targetType, true);
            var sourceProps = source.GetType().GetProperties();
            var sourcePropsNames = new string[sourceProps.Length];
            for (var i = 0; i < sourceProps.Length; i++)
                sourcePropsNames[i] = sourceProps[i].Name;

            foreach (var prop in targetProps)
            {
                if (!sourcePropsNames.Contains(prop.Name)) continue;
                var value = source
                    .GetType()
                    .GetProperty(prop.Name)?
                    .GetValue(source);

                if (value is SyntaxNode)
                {
                    var methodType = typeof(SyntaxNodeExtension);
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

        public static List<TTarget> ListClone<TSource, TTarget>(List<TSource> sourceList)
        {
            if (sourceList == null)
                return null;
            var targetList = new List<TTarget>();
            sourceList.ForEach(elem => targetList.Add(ObjectClone<TSource, TTarget>(elem)));
            return targetList;
        }

        public static List<TTarget> ListClone<TSource, TTarget>(TSource[] sourceList)
            => sourceList == null ? null : ListClone<TSource, TTarget>(sourceList.ToList());
        public static TTarget[] ArrayClone<TSource, TTarget>(List<TSource> sourceList) 
            => sourceList == null ? null : ArrayClone<TSource, TTarget>(sourceList.ToArray());
    }
}
