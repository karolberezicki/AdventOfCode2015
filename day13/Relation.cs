using System.Diagnostics;

namespace day13
{
    [DebuggerDisplay("From {From} To {To} = {Value}")]
    public class Relation
    {
        public Relation()
        {
            
        }

        public Relation(string instruction)
        {
            int sign = instruction.Contains("lose") ? -1 : 1;

            instruction = instruction.Replace("would ", "");
            instruction = instruction.Replace("happiness units by sitting next to ", "");
            instruction = instruction.Replace(".", "");
            instruction = instruction.Replace("\r", "");
            instruction = instruction.Replace("\n", "");

            string[] parts = instruction.Split(' ');
            From = parts[0];
            To = parts[3];
            Value = int.Parse(parts[2]) * sign;
        }

        public string From { get; set; }
        public string To { get; set; }
        public int Value { get; set; }

        public bool IsDistance(string from, string to)
        {
            return (From == from && To == to)
                   || (From == to && To == from);
        }
    }
}