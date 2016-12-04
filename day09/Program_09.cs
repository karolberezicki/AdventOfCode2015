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

            List<Distance> distances = instructions.Select(i => new Distance(i, false)).ToList();
            distances.AddRange(instructions.Select(i => new Distance(i, true)).ToList());

            List<string> cities = distances.Select(d => d.From).Distinct().ToList();

            int minimalDistance = int.MaxValue;
            int maximalDistance = 0;

            List<List<string>> citiesPermutations = GeneratePermutations(cities);

            foreach (List<string> permutation in citiesPermutations)
            {
                int distance = FindDistance(permutation, distances);

                if (distance < minimalDistance)
                {
                    minimalDistance = distance;
                }

                if (distance > maximalDistance)
                {
                    maximalDistance = distance;
                }
            }

            Console.WriteLine("Part one = {0}", minimalDistance);
            Console.WriteLine("Part two = {0}", maximalDistance);
            Console.ReadLine();
        }

        public static int FindDistance(List<string> cities, List<Distance> distances)
        {
            int distanceSum = 0;
            for (int i = 0; i < cities.Count - 1; i++)
            {
                Distance distance = distances.First(d => d.From == cities[i] && d.To == cities[i + 1]);
                distanceSum += distance.Value;
            }
            return distanceSum;
        }



        public static List<List<T>> GeneratePermutations<T>(List<T> items)
        {
            T[] current_permutation = new T[items.Count];
            bool[] in_selection = new bool[items.Count];
            List<List<T>> results = new List<List<T>>();
            PermuteItems(items, in_selection, current_permutation, results, 0);
            return results;
        }

        public static void PermuteItems<T>(List<T> items, bool[] in_selection,
            T[] current_permutation, List<List<T>> results,
            int next_position)
        {

            if (next_position == items.Count)
            {
                results.Add(current_permutation.ToList());
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];
                        PermuteItems(items, in_selection, current_permutation, results, next_position + 1);
                        in_selection[i] = false;
                    }
                }
            }
        }

    }

    public class Distance
    {

        public Distance(string instruction, bool reversed)
        {
            string[] parts = instruction.Split(' ');
            Value = int.Parse(parts[4]);

            if (reversed)
            {
                From = parts[0];
                To = parts[2];
            }
            else
            {
                From = parts[2];
                To = parts[0];
            }
        }

        public string From { get; set; }
        public string To { get; set; }
        public int Value { get; set; }
    }


}
