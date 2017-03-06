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
        public string Id { get; }
        
        public Identifier()
        {
            Id = GenerateId();
        }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
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
