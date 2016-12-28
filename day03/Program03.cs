using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day03
{
    class Program03
    {
        static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");

            // Part 1
            Point currentSantaLocation = new Point(0, 0);
            List<Point> visitedSantaHouses = new List<Point> {new Point(currentSantaLocation)};

            foreach (char direction in source)
            {
                currentSantaLocation.Move(direction);
                visitedSantaHouses.Add(new Point(currentSantaLocation));
            }

            List<IGrouping<Point, Point>> uniqueHouses =
                visitedSantaHouses.GroupBy(d => d).Select(d => d).ToList();
            Console.WriteLine("Unique visted houses by Santa count = {0}", uniqueHouses.Count);


            // Part 2
            currentSantaLocation = new Point(0, 0);
            visitedSantaHouses = new List<Point> {new Point(currentSantaLocation)};

            Point currentRoboSantaLocation = new Point(0, 0);
            List<Point> visitedRoboSantaHouses = new List<Point> {new Point(currentRoboSantaLocation)};

            bool isSantasTurn = true;

            foreach (char direction in source)
            {
                if (isSantasTurn)
                {
                    currentSantaLocation.Move(direction);
                    visitedSantaHouses.Add(new Point(currentSantaLocation));
                }
                else
                {
                    currentRoboSantaLocation.Move(direction);
                    visitedRoboSantaHouses.Add(new Point(currentRoboSantaLocation));
                }
                isSantasTurn = !isSantasTurn;
            }

            uniqueHouses = visitedSantaHouses.Concat(visitedRoboSantaHouses)
                .GroupBy(d => d).Select(d => d).ToList();

            Console.WriteLine("Unique visted houses by Santa and RoboSanta count = {0}", uniqueHouses.Count);

            Console.ReadLine();

        }
    }
}
