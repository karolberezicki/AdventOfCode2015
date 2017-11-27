using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day17
{
    public class Program17
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<int> containers = source.Split('\n').Select(int.Parse).ToList();
            var combos = GetAllCombos(containers);

            var allCombinationsThatCanHold150LitersOfEggnog = combos.Where(c => c.Sum() == 150).ToList();

            var combinationsCount = allCombinationsThatCanHold150LitersOfEggnog.Count;

            var minOfContainers =  allCombinationsThatCanHold150LitersOfEggnog.Select(c => c.Count).Min();

            var waysToSolveWithMinOfContainers = allCombinationsThatCanHold150LitersOfEggnog.Count(c => c.Count == minOfContainers);

            Console.WriteLine($"Part one: {combinationsCount}");
            Console.WriteLine($"Part two: {waysToSolveWithMinOfContainers}");

            Console.ReadKey();
        }

        // https://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values/40417765#40417765
        public static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            List<List<T>> result = new List<List<T>> {new List<T>()};
            // head
            result.Last().Add(list[0]);
            if (list.Count == 1)
                return result;
            // tail
            List<List<T>> tailCombos = GetAllCombos(list.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<T>(combo));
                combo.Add(list[0]);
                result.Add(new List<T>(combo));
            });
            return result;
        }
    }
}
