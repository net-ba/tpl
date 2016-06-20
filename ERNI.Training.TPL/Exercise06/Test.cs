using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ERNI.Training.TPL.Exercise06
{
    public class Test
    {
        [Fact]
        public void RemoveDuplicates_2Duplicates_10ItemsLeft()
        {
            var collection = new List<Item>
            {
                new Item() { Id = 1, Name = "Item1" },
                new Item() { Id = 3, Name = "Item3" },
                new Item() { Id = 4, Name = "Item4" },
                new Item() { Id = 7, Name = "Item7" },
                new Item() { Id = 2, Name = "Item2" },
                new Item() { Id = 2, Name = "Item2" },
                new Item() { Id = 8, Name = "Item8" },
                new Item() { Id = 5, Name = "Item5" },
                new Item() { Id = 3, Name = "Item3" },
                new Item() { Id = 6, Name = "Item6" },
                new Item() { Id = 5, Name = "Item5" },
                new Item() { Id = 9, Name = "Item9" }
            };
            var implement = new Implement();

            var result = implement.RemoveDuplicates(collection);

            var expected = new List<Item>
            {
                new Item() { Id = 1, Name = "Item1" },
                new Item() { Id = 2, Name = "Item2" },
                new Item() { Id = 3, Name = "Item3" },
                new Item() { Id = 4, Name = "Item4" },
                new Item() { Id = 5, Name = "Item5" },
                new Item() { Id = 6, Name = "Item6" },
                new Item() { Id = 7, Name = "Item7" },
                new Item() { Id = 8, Name = "Item8" },
                new Item() { Id = 9, Name = "Item9" }
            };

            Assert.Equal(expected, result.OrderBy(i => i.Id));
        }
    }
}
