namespace day09
{
    public class Distance
    {
        public Distance(string instruction)
        {
            string[] parts = instruction.Split(' ');
            From = parts[0];
            To = parts[2];
            Value = int.Parse(parts[4]);
        }

        public string From { get; set; }
        public string To { get; set; }
        public int Value { get; set; }

        public bool IsDistance(string From, string To)
        {
            return (this.From == From && this.To == To)
                || (this.From == To && this.To == From);
        }
    }
}
