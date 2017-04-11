using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph
{
    [Serializable]
    public sealed class Identifier
    {
        private static readonly ConcurrentBag<string> UniqueIdSet;
        static Identifier()
        {
            UniqueIdSet = new ConcurrentBag<string>();
        }

        public string Id { get; }
        
        internal Identifier(string id = null)
        {
            Id = id ?? GetId();
            if (UniqueIdSet.Contains(Id))
                throw new DuplicateNameException("Cannot have two instances of the same name!");
            UniqueIdSet.Add(Id);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Identifier;
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
        
        public static Identifier Generate()
        {
            return new Identifier();
        }
        private static string GetId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
