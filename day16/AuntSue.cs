namespace day16
{
    public partial class Program15
    {
        public class AuntSue
        {
            public AuntSue(string i)
            {
                i = i.Replace("Sue", "").Replace(" ", "");
                Number = int.Parse(i.Substring(0, i.IndexOf(':')));
                var compounds = i.Substring(i.IndexOf(':') + 1).Split(',');

                foreach (string compound in compounds)
                {
                    SetCompounds(compound);
                }
            }

            public int Number { get; set; }

            public int? children { get; set; }
            public int? cats { get; set; }
            public int? samoyeds { get; set; }
            public int? pomeranians { get; set; }
            public int? akitas { get; set; }
            public int? vizslas { get; set; }
            public int? goldfish { get; set; }
            public int? trees { get; set; }
            public int? cars { get; set; }
            public int? perfumes { get; set; }

            private void SetCompounds(string compound)
            {
                var compoundSplited = compound.Split(':');
                var compoundValue = int.Parse(compoundSplited[1]);
                switch (compoundSplited[0])
                {
                    case nameof(children):
                        children = compoundValue;
                        break;
                    case nameof(cats):
                        cats = compoundValue;
                        break;
                    case nameof(samoyeds):
                        samoyeds = compoundValue;
                        break;
                    case nameof(pomeranians):
                        pomeranians = compoundValue;
                        break;
                    case nameof(akitas):
                        akitas = compoundValue;
                        break;
                    case nameof(vizslas):
                        vizslas = compoundValue;
                        break;
                    case nameof(goldfish):
                        goldfish = compoundValue;
                        break;
                    case nameof(trees):
                        trees = compoundValue;
                        break;
                    case nameof(cars):
                        cars = compoundValue;
                        break;
                    case nameof(perfumes):
                        perfumes = compoundValue;
                        break;
                }
            }
        }
    }
}