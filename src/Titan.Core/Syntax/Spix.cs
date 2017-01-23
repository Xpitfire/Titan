using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Syntax
{
    [Serializable]
    public struct Spix
    {
        public static readonly IList<string> UniqueSpixLSet;
        public static readonly Spix Empty;

        public string Name { get; internal set; }
        public int Length { get; internal set; }

        static Spix()
        {
            UniqueSpixLSet = new List<string>();
            Empty = new Spix();
        }

        public Spix(string name = null)
        {
            if (UniqueSpixLSet.Contains(name))
            {
                throw new ArgumentException($"Spix name collision: {name} already defined!");
            }
            if (name == null)
            {
                name = Guid.NewGuid().ToString();
            }
            Name = name;
            Length = name.Length;
            UniqueSpixLSet.Add(name);
        }
        

        public override bool Equals(object obj)
        {
            var other = obj as Spix?;
            return other != null && Name.Equals(other.Value.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(Spix value1, Spix value2)
        {
            return value1.Equals(value2);
        }

        public static bool operator !=(Spix value1, Spix value2)
        {
            return !value1.Equals(value2);
        }

    }
}
