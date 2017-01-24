using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class Spix
    {
        public static readonly BlockingCollection<string> UniqueSpixLSet;
        public static readonly Spix Empty;

        public string Id { get; private set; }

        static Spix()
        {
            UniqueSpixLSet = new BlockingCollection<string>();
            Empty = new Spix();
        }

        public Spix(string id = null)
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
            var other = obj as Spix;
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Spix value1, Spix value2) => value1 != null && value1.Equals(value2);

        public static bool operator !=(Spix value1, Spix value2) => value1 != null && !value1.Equals(value2);
    }
}
