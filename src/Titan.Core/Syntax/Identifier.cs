using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class Identifier
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwyxz";
        private const int DefaultIdSize = 10;
        private static readonly Random Random = new Random();
        private static readonly ConcurrentBag<string> UniqueIdSet;

        public static readonly Identifier Empty;

        public string Id { get; }

        static Identifier()
        {
            UniqueIdSet = new ConcurrentBag<string>();
            Empty = new Identifier();
        }

        public Identifier(string id = null)
        {
            if (UniqueIdSet.Contains(id))
            {
                throw new ArgumentException(
                    $"Id collision: {id} already defined!");
            }
            if (id == null)
            {
                id = GenerateId();
            }
            Id = id;
            UniqueIdSet.Add(id);
        }

        private string GenerateId()
        {
            var sb = new StringBuilder();
            do
            {
                sb.Append(Alphabet[Random.Next(Alphabet.Length)]);
                for (int i = 0; i < DefaultIdSize; i++)
                {
                    sb.Append(Alphabet[Random.Next(Alphabet.Length)]);
                }
            } while (UniqueIdSet.Contains(sb.ToString()));
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Identifier;
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Identifier value1, Identifier value2) => value1 != null && value1.Equals(value2);
        public static bool operator !=(Identifier value1, Identifier value2) => value1 != null && !value1.Equals(value2);
    }
}
