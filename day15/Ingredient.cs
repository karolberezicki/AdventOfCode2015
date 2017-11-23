using System.Diagnostics;
using System.Text.RegularExpressions;

namespace day15
{
    [DebuggerDisplay("{Name}: Capacity {Capacity}, Durability {Durability}, Flavor {Flavor}, Texture {Texture}, Calories {Calories}")]
    public class Ingredient
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavor { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }


        public Ingredient(string instruction)
        {
            const string pattern = @"(\w+)\: capacity ([-+]?[0-9]+), durability ([-+]?[0-9]+), flavor ([-+]?[0-9]+), texture ([-+]?[0-9]+), calories ([-+]?[0-9]+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(instruction);

            Name = match.Groups[1].Value;
            Capacity = int.Parse(match.Groups[2].Value);
            Durability = int.Parse(match.Groups[3].Value);
            Flavor = int.Parse(match.Groups[4].Value);
            Texture = int.Parse(match.Groups[5].Value);
            Calories = int.Parse(match.Groups[6].Value);
        }
    }
}