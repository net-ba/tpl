using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise06
{
    public class Item : IEquatable<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Equals(Item other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ (Name?.GetHashCode() ?? 0);
        }
    }
}
