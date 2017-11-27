using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day15
{
    public class Program15
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            List<string> instructions = source.Split('\n').ToList();

            var ingridients = instructions.Select(i => new Ingredient(i)).ToList();
            List<int[]> mixtures = GenerateMixtures(ingridients.Count);

            var scores = new List<int>();
            foreach (int[] mixture in mixtures)
            {
                var cp = new List<int>();
                var dr = new List<int>();
                var fl = new List<int>();
                var tx = new List<int>();

                for (int j = 0; j < mixture.Length; j++)
                {
                    cp.Add(ingridients[j].Capacity * mixture[j]);
                    dr.Add(ingridients[j].Durability * mixture[j]);
                    fl.Add(ingridients[j].Flavor * mixture[j]);
                    tx.Add(ingridients[j].Texture * mixture[j]);
                }

                var subScores = new List<int> { cp.Sum(), dr.Sum(), fl.Sum(), tx.Sum() };

                int score = subScores.Any(c => c < 0) ? 0 : subScores.Aggregate(1, (acc, val) => acc * val);

                scores.Add(score);
            }

            var maxScore = scores.Max();

            Console.ReadKey();
        }

        private static List<int[]> GenerateMixtures(int count)
        {
            var mixtures = new List<int[]>();

            // TODO: Dirty hack, sorry for readers
            switch (count)
            {
                case 2:
                    for (int i = 0; i <= 100; i++)
                    {
                        for (int j = 0; j <= 100; j++)
                        {
                            if (i + j == 100)
                            {
                                mixtures.Add(new[] { i, j });
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i <= 100; i++)
                    {
                        for (int j = 0; j <= 100; j++)
                        {
                            for (int k = 0; k <= 100; k++)
                            {
                                for (int l = 0; l <= 100; l++)
                                {
                                    if (i + j +k + l == 100)
                                    {
                                        mixtures.Add(new[] { i, j, k, l });
                                    }
                                }
                            }
                        }
                    }
                    break;
                    default:
                    throw new NotImplementedException();
            }

            return mixtures;
        }
    }
}