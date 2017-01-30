using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Core.Helper
{
    [Serializable]
    public class ImmutableList<T> : List<T>
    {
        internal ImmutableList() : this(null) { }
        internal ImmutableList(ImmutableList<T> layers) : this(layers, null) { }
        internal ImmutableList(ImmutableList<T> layers, params T[] otherLayers)
        {
            if (layers != null && layers.Count > 0)
                base.AddRange(layers);
            if (otherLayers != null && otherLayers.Length > 0)
                base.AddRange(otherLayers);
        }

        public new void Add(T element) => throw new ImmutableListException();
        public new void AddRange(IEnumerable<T> collection) => throw new ImmutableListException();
        public new void Clear() => throw new ImmutableListException();
        public new void Insert(int index, T item) => throw new ImmutableListException();
        public new void InsertRange(int index, IEnumerable<T> collection) => throw new ImmutableListException();
        public new bool Remove(T item) => throw new ImmutableListException();
        public new int RemoveAll(Predicate<T> match) => throw new ImmutableListException();
        public new void RemoveAt(int index) => throw new ImmutableListException();
        public new void RemoveRange(int index, int count) => throw new ImmutableListException();
        public new void Reverse(int index, int count) => throw new ImmutableListException();
        public new void Reverse() => throw new ImmutableListException();
        public new void Sort(int index, int count, IComparer<T> comparer) => throw new ImmutableListException();
        public new void Sort(Comparison<T> comparison) => throw new ImmutableListException();
        public new void Sort() => throw new ImmutableListException();
        public new void Sort(IComparer<T> comparer) => throw new ImmutableListException();
    }

    [Serializable]
    internal class ImmutableListException : Exception
    {
        public ImmutableListException()
        {
        }

        public ImmutableListException(string message) : base(message)
        {
        }

        public ImmutableListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImmutableListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
