using System;
using System.Collections;
using System.Collections.Generic;
using Titan.Core.Immutable;
using Titan.Core.Syntax;

namespace Titan.Core.Collection
{
    [Serializable]
    public sealed class ImmutableList<T> : IList<T>
    {
        private readonly List<T> _data = new List<T>();

        public int Count => _data.Count;
        public bool IsReadOnly => true;

        public T this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }

        private ImmutableList() { }
        internal ImmutableList(ImmutableList<T> layers)
        {
            _data = layers.ToList();
        }
        internal ImmutableList(ImmutableList<T> layers, params IList<T>[] otherLayers)
        {
            if (layers != null)
            {
                foreach (var layer in layers)
                {
                    if (layer != null)
                        _data.Add(layer);
                }
            }
            lock (_data)
            {
                foreach (var layer in otherLayers)
                {
                    if (layer != null)
                        _data.AddRange(layer);
                }
            }
        }
        internal ImmutableList(ImmutableList<T> layers, params ImmutableList<T>[] otherLayers)
        {
            if (layers != null)
            {
                foreach (var layer in layers)
                {
                    if (layer != null)
                        _data.Add(layer);
                }
            }
            if (otherLayers != null)
            {
                foreach (var layer in otherLayers)
                {
                    if (layer != null)
                        _data.AddRange(layer);
                }
            }
        }
        internal ImmutableList(ImmutableList<T> layers, params T[] otherLayers)
        {
            if (layers != null)
            {
                foreach (var layer in layers)
                {
                    if (layer != null)
                        _data.Add(layer);
                }
            }
            if (otherLayers != null)
            {
                foreach (var layer in otherLayers)
                {
                    if (layer != null)
                        _data.Add(layer);
                }
            }
        }
        internal ImmutableList(IList<T> list)
        {
            if (list == null) return;
            foreach (var item in list)
            {
                if (item != null)
                    _data.Add(item);
            }
        }
        internal ImmutableList(T[] array)
        {
            if (array != null)
            {
                foreach (var layer in array)
                {
                    _data.Add(layer);
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

        public int IndexOf(T item) => _data.IndexOf(item);
        public bool Contains(T item) => _data.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _data.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
        public void ForEach(Action<T> p)
        {
            foreach (var item in _data)
            {
                p?.Invoke(item);
            }
        }
        /// <summary>
        /// Creates always a new list object containing the elements.
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            var list = new List<T>();
            foreach (var item in _data)
            {
                list.Add(item);
            }
            return list;
        }
    }

    public static class ImmutableListExtension
    {
        public static ImmutableList<T> ToImmutableList<T>(this IList<T> list)
        {
            return new ImmutableList<T>(list);
        }

        public static ImmutableList<T> ToImmutableList<T>(this T[] array)
        {
            return new ImmutableList<T>(array);
        }

        public static ImmutableList<T> Remove<T>(this ImmutableList<T> immutableList, T element)
        {
            var list = immutableList.ToList();
            list.Remove(element);
            return list.ToImmutableList();
        }
    }

}
