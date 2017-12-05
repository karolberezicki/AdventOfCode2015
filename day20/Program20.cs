using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day20
{
    public class Program20
    {
        public static void Main(string[] args)
        {
            var input = 34000000;

            int partOne = PartOne(input);
            var partTwo = PartTwo(input);

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
                var housePresents = Factor(houseNumber)
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
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }

            return factors;
        }

    }

}
