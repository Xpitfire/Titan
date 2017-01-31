using System;
using System.Collections;
using System.Collections.Generic;
using Titan.Core.Immutable;

namespace Titan.Core.Collection
{
    [Serializable]
    public sealed class ImmutableList<T> : IList<T>
    {
        private readonly IList<T> Data = new List<T>();

        public int Count => Data.Count;
        public bool IsReadOnly => true;

        public T this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        internal ImmutableList() { }
        internal ImmutableList(ImmutableList<T> layers) : this(layers, null) { }
        internal ImmutableList(ImmutableList<T> layers, params T[] otherLayers)
        {
            if (layers != null)
            {
                foreach (var layer in layers)
                {
                    Data.Add(layer);
                }
            }
            if (otherLayers != null)
            {
                foreach (var layer in otherLayers)
                {
                    Data.Add(layer);
                }
            }
        }
        internal ImmutableList(IList<T> list)
        {
            Data = list;
        }
        internal ImmutableList(T[] array)
        {
            if (array != null)
            {
                foreach (var layer in array)
                {
                    Data.Add(layer);
                }
            }
        }

        public void Add(T element) => throw new ImmutableException();
        public void AddRange(IEnumerable<T> collection) => throw new ImmutableException();
        public void Clear() => throw new ImmutableException();
        public void Insert(int index, T item) => throw new ImmutableException();
        public void InsertRange(int index, IEnumerable<T> collection) => throw new ImmutableException();
        public bool Remove(T item) => throw new ImmutableException();
        public int RemoveAll(Predicate<T> match) => throw new ImmutableException();
        public void RemoveAt(int index) => throw new ImmutableException();
        public void RemoveRange(int index, int count) => throw new ImmutableException();
        public void Reverse(int index, int count) => throw new ImmutableException();
        public void Reverse() => throw new ImmutableException();
        public void Sort(int index, int count, IComparer<T> comparer) => throw new ImmutableException();
        public void Sort(Comparison<T> comparison) => throw new ImmutableException();
        public void Sort() => throw new ImmutableException();
        public void Sort(IComparer<T> comparer) => throw new ImmutableException();

        public int IndexOf(T item) => Data.IndexOf(item);
        public bool Contains(T item) => Data.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => Data.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
        public List<T> ToList()
        {
            var list = new List<T>();
            foreach (var item in Data)
            {
                list.Add(item);
            }
            return list;
        }
    }

    public static class IListExtension
    {
        public static ImmutableList<T> ToImmutableList<T>(this IList<T> list)
        {
            return new ImmutableList<T>(list);
        }

        public static ImmutableList<T> ToImmutableList<T>(this T[] array)
        {
            return new ImmutableList<T>(array);
        }
    }

}
