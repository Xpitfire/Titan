using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph
{
    [Serializable]
    public class Relationship
    {
        public string Node1 { get; set; }
        public string Node2 { get; set; }
        public bool Cycle { get; set; }

        public Relationship()
        {
        }

        public Relationship(string node1, string node2, bool cycle)
        {
            this.Node1 = node1;
            this.Node2 = node2;
            Cycle = cycle;
        }

        protected bool Equals(Relationship other)
        {
            return (Equals(Node1, other.Node1)
                && Equals(Node2, other.Node2))
                || (Cycle && Equals(Node1, other.Node2)
                && Equals(Node2, other.Node1));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Relationship)obj);
        }

        public override int GetHashCode()
        {
            return (Node1?.GetHashCode() + Node2?.GetHashCode()) ?? 0;
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public static class ReferenceExtensions {

        public static IList<Relationship> ResolveDistinctCycles(this IList<Relationship> relationships)
        {
            var dict = relationships.ToDictionary(r => $"{r.Node1}->{r.Node2}", r => r);
            var resultList = new List<Relationship>();
            foreach (var r in relationships)
            {
                if (dict.TryGetValue($"{r.Node2}->{r.Node1}", out Relationship relation))
                {
                    r.Cycle = true;
                    if (resultList.Contains(r)) continue;
                    resultList.Add(r);
                }
                else
                {
                    resultList.Add(r);
                }
            }
            return resultList;
        }

    }
}
