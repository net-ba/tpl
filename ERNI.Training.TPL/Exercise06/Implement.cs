using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise06
{
    /// <summary>
    /// Make LINQ parallel
    /// </summary>
    public class Implement
    {
        public IEnumerable<Item> RemoveDuplicates(IEnumerable<Item> collection)
        {
            return collection.Where((item, index) => index == 0 || !collection.Take(index).Contains(item));
        }
    }
}
