using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day12
{
    public class Program_12
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText(@"..\..\input.txt");

            int partOne = new Regex(@"-?\d+").Matches(input).Cast<Match>()
                .Select(m => int.Parse(m.Value)).Sum();

            JArray json = (JArray)JsonConvert.DeserializeObject(input);
            long partTwo = GetSum(json, "red");

            Console.WriteLine("Part one = {0}", partOne);
            Console.WriteLine("Part two = {0}", partTwo);

            Console.ReadLine();
        }

        public static long GetSum(JObject o, string avoid = null)
        {
            bool shouldAvoid = o.Properties()
                .Select(a => a.Value).OfType<JValue>()
                .Select(v => v.Value).Contains(avoid);
            if (shouldAvoid) return 0;

            return o.Properties().Sum((dynamic a) => (long)GetSum(a.Value, avoid));
        }
        public static long GetSum(JArray arr, string avoid)
        {
            return arr.Sum((dynamic a) => (long)GetSum(a, avoid));
        }
        public static long GetSum(JValue val, string avoid)
        {
            return val.Type == JTokenType.Integer ? (long)val.Value : 0;
        }
    }
}
