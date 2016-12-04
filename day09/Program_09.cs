using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day09
{
    public class Program_09
    {
        public static void Main(string[] args)
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> instructions = source.Split('\n').ToList();

            List<Distance> distances = instructions.Select(i => new Distance(i)).ToList();

            List<string> cities = distances.Select(d => d.From)
                .Concat(distances.Select(d => d.To))
                .Distinct().ToList();

            List<List<string>> citiesPermutations = Permutations.GeneratePermutations(cities);

            IEnumerable<int> pathDistances = citiesPermutations
                .Select(permutation => FindDistance(permutation, distances));

            int minimalDistance = pathDistances.Min();
            int maximalDistance = pathDistances.Max();

            Console.WriteLine("Part one = {0}", minimalDistance);
            Console.WriteLine("Part two = {0}", maximalDistance);
            Console.ReadLine();
        }

        public static int FindDistance(List<string> cities, List<Distance> distances)
        {
            int distanceSum = 0;
            for (int i = 0; i < cities.Count - 1; i++)
            {
                Distance distance = distances.First(d => d.IsDistance(cities[i], cities[i + 1]));
                distanceSum += distance.Value;
            }
            return distanceSum;
        }

    }

}
