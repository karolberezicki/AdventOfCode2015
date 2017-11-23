using System;
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

            List<RaceState> racers = reindeers.Select(r => new RaceState { Reindeer = r }).ToList();
            RaceState winnerOfSecondRace = GetWinnerOfSecondRace(secondsCount, racers);

            Console.WriteLine($"Winning distance of first race: {winningReindeerDistance}");
            Console.WriteLine($"Winner of second race: {winnerOfSecondRace.Reindeer.Name} with {winnerOfSecondRace.Points} points.");
            Console.ReadKey();

        }

        private static int GetWinningReindeerDistance(IEnumerable<Reindeer> reindeers, int secondsCount)
        {
            List<KeyValuePair<Reindeer, int>> reindeersWithTraveledDistance = reindeers
                .Select(r => new KeyValuePair<Reindeer, int>(r, r.GetTraveledDistance(secondsCount)))
                .ToList();

            return reindeersWithTraveledDistance.OrderByDescending(rwd => rwd.Value).First().Value;
        }

        private static RaceState GetWinnerOfSecondRace(int secondsCount, List<RaceState> racers)
        {
            for (int i = 0; i < secondsCount; i++)
            {
                foreach (RaceState racer in racers)
                {
                    if (racer.RunTime == racer.Reindeer.TravelTime)
                    {
                        racer.RunTime = 0;
                        racer.RestTime = racer.Reindeer.RestTime - 1;
                        continue;
                    }

                    if (racer.RestTime > 0)
                    {
                        racer.RestTime -= 1;
                        continue;
                    }

                    racer.Traveled += racer.Reindeer.Velocity;
                    racer.RunTime += 1;
                }

                int currentWinningDistance = racers.Select(r => r.Traveled).Max();

                foreach (RaceState racer in racers)
                {
                    if (racer.Traveled == currentWinningDistance)
                    {
                        racer.Points += 1;
                    }
                }
            }

            RaceState winnerOfSecondRace = racers.OrderByDescending(r => r.Points).First();
            return winnerOfSecondRace;
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

    [DebuggerDisplay("{Reindeer.Name} {Reindeer.Velocity} km/s | Trav: {Traveled} Run:{RunTime} Rest:{RestTime} P:{Points}")]
    public class RaceState
    {
        public Reindeer Reindeer { get; set; }
        public int Traveled { get; set; }
        public int RunTime { get; set; }
        public int RestTime { get; set; }
        public int Points { get; set; }
    }

}
