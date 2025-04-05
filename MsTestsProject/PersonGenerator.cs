using SorterLibrary;
using System;
using System.Linq;

namespace MsTestsProject
{
    public enum PersonOrder
    {
        Random,
        Ascending,
        Descending
    }
    public class PersonGenerator
    {
        public static Person[] Generate(int size, int seed, PersonOrder order = PersonOrder.Random)
        {
            var rand = new Random(seed);

            // Generate base list with random IDs
            var people = Enumerable.Range(0, size)
                .Select(_ => new Person(rand.Next(1, 100001)))
                .ToArray();

            return order switch
            {
                PersonOrder.Ascending => people.OrderBy(p => p.Id).ToArray(),
                PersonOrder.Descending => people.OrderByDescending(p => p.Id).ToArray(),
                _ => people
            };
        }
    }
}
