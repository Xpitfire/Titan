using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class IdentifierSyntax
    {
        public static readonly ConcurrentBag<string> UniqueSpixLSet;
        public static readonly IdentifierSyntax Empty;

        public string Id { get; private set; }

        static IdentifierSyntax()
        {
            UniqueSpixLSet = new ConcurrentBag<string>();
            Empty = new IdentifierSyntax();
        }

        public IdentifierSyntax(string id = null)
        {
            if (UniqueSpixLSet.Contains(id))
            {
                throw new ArgumentException($"Spix id collision: {id} already defined!");
            }
            if (id == null)
            {
                id = Guid.NewGuid().ToString();
            }
            Id = id;
            UniqueSpixLSet.Add(id);
        }
        

        public override bool Equals(object obj)
        {
            var other = obj as IdentifierSyntax;
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(IdentifierSyntax value1, IdentifierSyntax value2) => value1 != null && value1.Equals(value2);

        public static bool operator !=(IdentifierSyntax value1, IdentifierSyntax value2) => value1 != null && !value1.Equals(value2);
    }
}
