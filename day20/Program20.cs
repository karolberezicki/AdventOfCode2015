using System;
using System.Collections.Generic;
using System.Linq;

namespace day20
{
    public class Program20
    {
        public static void Main(string[] args)
        {
            const int input = 34000000;

            int partOne = PartOne(input);
            int partTwo = PartTwo(input);

            Console.WriteLine($"Part one: {partOne}");
            Console.WriteLine($"Part two: {partTwo}");

            Console.ReadKey();
        }


        public static int PartOne(int input)
        {
            for (int houseNumber = 1; ; houseNumber++)
            {
                int housePresents = Factor(houseNumber).Sum() * 10;

                if (housePresents >= input)
                {
                    return houseNumber;
                }
            }
        }

        public static int PartTwo(int input)
        {
            for (int houseNumber = 1; ; houseNumber++)
            {
                int housePresents = Factor(houseNumber)
                    .Where(c => houseNumber / c <= 50 || c == 1)
                    .Sum() * 11;

                if (housePresents >= input)
                {
                    return houseNumber;
                }
            }
        }

        // Credit to: https://stackoverflow.com/a/239877/7454424
        public static List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);
            for (int factor = 1; factor <= max; ++factor)
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    {
                        factors.Add(number / factor);
                    }
                }
            }

            return factors;
        }

    }

}
