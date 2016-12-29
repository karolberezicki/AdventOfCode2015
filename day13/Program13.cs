using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day13
{
    public class Program13
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> instructions = source.Split('\n').ToList();

            List<Relation> relations = instructions.Select(i => new Relation(i)).ToList();

            List<string> names = relations.Select(r => r.From).Union(relations.Select(r => r.To)).Distinct().ToList();

            int partOne = CalculateTotalChangeOfHappiness(relations, names);

            AddMeToTable(relations, names);
            int partTwo = CalculateTotalChangeOfHappiness(relations, names);

            Console.WriteLine("Part one = {0}", partOne);
            Console.WriteLine("Part two = {0}", partTwo);
            Console.ReadLine();
        }

        private static void AddMeToTable(List<Relation> relations, ICollection<string> names)
        {
            const string me = "Me";
            relations.AddRange(names.Select(name => new Relation {From = me, To = name, Value = 0}));
            names.Add(me);
        }

        private static int CalculateTotalChangeOfHappiness(List<Relation> relations, List<string> names)
        {
            List<List<string>> permutations = Permutations.GeneratePermutations(names);

            List<Arrangement> permutationsWithHappiness = permutations
                .Select(p => new Arrangement { Names = p, Happiness = CalculateHappiness(p, relations) })
                .ToList();

            Arrangement arrangement = permutationsWithHappiness.OrderByDescending(i => i.Happiness).First();

            return arrangement.Happiness;
        }

        public static int CalculateHappiness(List<string> names, List<Relation> relations)
        {
            int totalValue = 0;

            for (int i = 0; i < names.Count-1; i++)
            {
                List<Relation> relationsBetweenTwo = relations.Where(r => r.IsDistance(names[i], names[i + 1])).ToList();
                totalValue += relationsBetweenTwo.Sum(relation => relation.Value);
            }

            List<Relation> lastRelationsBetweenTwo = relations.Where(r => r.IsDistance(names.First(), names.Last())).ToList();
            totalValue += lastRelationsBetweenTwo.Sum(relation => relation.Value);

            return totalValue;
        }
        

    }
}
