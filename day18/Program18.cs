using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day18
{
    public class Program18
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            bool[][] input = source.Replace("\r", "").Split('\n').Select(c => c.Select(b => b == '#').ToArray()).ToArray();

            int partOne = PartOne(input);
            int partTwo = PartTwo(input);

            Console.WriteLine($"Part one: {partOne}");
            Console.WriteLine($"Part two: {partTwo}");

            Console.ReadKey();
        }

        private static int PartOne(bool[][] input)
        {
            bool[][] partOneGrid = input.Select(a => a.ToArray()).ToArray();
            int size = partOneGrid.Length;

            for (int steps = 0; steps < 100; steps++)
            {
                bool[][] copy = partOneGrid.Select(a => a.ToArray()).ToArray();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        List<bool> neighbors = GetNeighbors(i, j, partOneGrid);
                        int countOnNeighbors = neighbors.Count(c => c);

                        if (partOneGrid[i][j])
                        {

                            copy[i][j] = countOnNeighbors == 2 || countOnNeighbors == 3;
                        }
                        else
                        {
                            copy[i][j] = countOnNeighbors == 3;
                        }
                    }
                }
                partOneGrid = copy;
            }

            return partOneGrid.SelectMany(c => c).Count(c => c);
        }


        private static int PartTwo(bool[][] input)
        {
            bool[][] partTwoGrid = input.Select(a => a.ToArray()).ToArray();
            int size = partTwoGrid.Length;

            partTwoGrid[0][0] = true;
            partTwoGrid[0][size - 1] = true;
            partTwoGrid[size - 1][0] = true;
            partTwoGrid[size - 1][size - 1] = true;

            for (int steps = 0; steps < 100; steps++)
            {
                bool[][] copy = partTwoGrid.Select(a => a.ToArray()).ToArray();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == 0 && j == 0 || i == 0 && j == size - 1|| i == size - 1 && j == 0 || i == size - 1 && j == size - 1)
                        {
                            continue;
                        }

                        List<bool> neighbors = GetNeighbors(i, j, partTwoGrid);
                        int countOnNeighbors = neighbors.Count(c => c);

                        if (partTwoGrid[i][j])
                        {

                            copy[i][j] = countOnNeighbors == 2 || countOnNeighbors == 3;
                        }
                        else
                        {
                            copy[i][j] = countOnNeighbors == 3;
                        }
                    }
                }
                partTwoGrid = copy;
            }

            return partTwoGrid.SelectMany(c => c).Count(c => c);
        }

        public static List<T> GetNeighbors<T>(int i, int j, T[][] cellValues)
        {
            int size = cellValues.Length;

            List<T> neighbors = new List<T> ();

            if (IsInsideArray(i, j, size))
            {
                if (IsInsideArray(i + 1, j, size))
                    neighbors.Add(cellValues[i + 1][j]);
                if (IsInsideArray(i - 1, j, size))
                    neighbors.Add(cellValues[i - 1][j]);
                if (IsInsideArray(i, j + 1, size))
                    neighbors.Add(cellValues[i][j + 1]);
                if (IsInsideArray(i, j - 1, size))
                    neighbors.Add(cellValues[i][j - 1]);
                if (IsInsideArray(i - 1, j + 1, size))
                    neighbors.Add(cellValues[i - 1][j + 1]);
                if (IsInsideArray(i + 1, j - 1, size))
                    neighbors.Add(cellValues[i + 1][j - 1]);
                if (IsInsideArray(i + 1, j + 1, size))
                    neighbors.Add(cellValues[i + 1][j + 1]);
                if (IsInsideArray(i - 1, j - 1, size))
                    neighbors.Add(cellValues[i - 1][j - 1]);
            }
            return neighbors;
        }

        public static bool IsInsideArray(int i, int j, int size)
        {
            return i >= 0 && i < size && j >= 0 && j < size;
        }

    }
}
