using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day16
{
    public partial class Program15
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            List<string> instructions = source.Split('\n').Take(500).ToList();

            List<AuntSue> auntSues = instructions.Select(i => new AuntSue(i)).ToList();
            int auntForPartOne = FindAuntForPartOne(auntSues);
            int auntForPartTwo = FindAuntForPartTwo(auntSues);

            Console.WriteLine($"Aunt Sue - part one number : {auntForPartOne}");
            Console.WriteLine($"Aunt Sue - part two number : {auntForPartTwo}");

            Console.ReadKey();
        }

        private static int FindAuntForPartOne(IEnumerable<AuntSue> auntSues)
        {
            return auntSues.First(a => (a.children == 3 || a.children == null) &&
                                       (a.cats == 7 || a.cats == null) &&
                                       (a.samoyeds == 2 || a.samoyeds == null) &&
                                       (a.pomeranians == 3 || a.pomeranians == null) &&
                                       (a.akitas == 0 || a.akitas == null) &&
                                       (a.vizslas == 0 || a.vizslas == null) &&
                                       (a.goldfish == 5 || a.goldfish == null) &&
                                       (a.trees == 3 || a.trees == null) &&
                                       (a.cars == 2 || a.cars == null) &&
                                       (a.perfumes == 1 || a.perfumes == null)).Number;
        }

        private static int FindAuntForPartTwo(IEnumerable<AuntSue> auntSues)
        {
            return auntSues.First(a => (a.children == 3 || a.children == null) &&
                                       (a.cats > 7 || a.cats == null) &&
                                       (a.samoyeds == 2 || a.samoyeds == null) &&
                                       (a.pomeranians < 3 || a.pomeranians == null) &&
                                       (a.akitas == 0 || a.akitas == null) &&
                                       (a.vizslas == 0 || a.vizslas == null) &&
                                       (a.goldfish < 5 || a.goldfish == null) &&
                                       (a.trees > 3 || a.trees == null) &&
                                       (a.cars == 2 || a.cars == null) &&
                                       (a.perfumes == 1 || a.perfumes == null)).Number;
        }
    }
}