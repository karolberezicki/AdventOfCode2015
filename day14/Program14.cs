﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day14
{
    public class Program14
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> instructions = source.Split('\n').ToList();

            List<Reindeer> reindeers = instructions.Select(i => new Reindeer(i)).ToList();

            const int secondsCount = 2503;
            var winningReindeerDistance = GetWinningReindeerDistance(reindeers, secondsCount);


            Console.WriteLine($"Winning distance: {winningReindeerDistance}");
            Console.ReadKey();

        }

        private static int GetWinningReindeerDistance(IEnumerable<Reindeer> reindeers, int secondsCount)
        {
            List<KeyValuePair<Reindeer, int>> reindeersWithTraveledDistance = reindeers
                .Select(r => new KeyValuePair<Reindeer, int>(r, r.GetTraveledDistance(secondsCount)))
                .ToList();

            return reindeersWithTraveledDistance.OrderByDescending(rwd => rwd.Value).First().Value;
        }
    }

    [DebuggerDisplay("{Name} {Velocity} km/s for {TravelTime} s, Rest = {RestTime}")]

    public class Reindeer
    {
        public string Name { get; set; }
        public int Velocity { get; set; }
        public int TravelTime { get; set; }
        public int RestTime { get; set; }


        public Reindeer(string instruction)
        {
            // Dancer can fly 27 km/s for 5 seconds, but then must rest for 132 seconds.
            Regex regex = new Regex(@"(?<Name>\w+) can fly (?<Velocity>\d+) km\/s for (?<TravelTime>\d+) seconds, but then must rest for (?<RestTime>\d+) seconds");
            Match match = regex.Match(instruction);

            Name = match.Groups["Name"].Value;
            Velocity = int.Parse(match.Groups["Velocity"].Value);
            TravelTime = int.Parse(match.Groups["TravelTime"].Value);
            RestTime = int.Parse(match.Groups["RestTime"].Value);
        }


        public int GetTraveledDistance(int afterTimeInSeconds)
        {
            int time = 0;
            int distance = 0;

            while (time < afterTimeInSeconds)
            {
                if (time + TravelTime < afterTimeInSeconds)
                {
                    distance += Velocity * TravelTime;
                    time += TravelTime;
                }
                else if (afterTimeInSeconds <= TravelTime)
                {
                    distance += Velocity * afterTimeInSeconds;
                    time += afterTimeInSeconds;
                }
                time += RestTime;
            }

            return distance;
        }
    }
}
