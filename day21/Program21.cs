using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace day21
{
    public class Program21
    {
        public static void Main(string[] args)
        {
            const int PlayerStartingHitPoints = 100;

            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<int> bossStats = string.Join("", source.Where(c => char.IsDigit(c) || c == '\n')).Split('\n').Select(int.Parse).ToList();
            RpgCharacter boss = new RpgCharacter{HitPoints = bossStats[0], Damage = bossStats[1], Armor = bossStats[2]};

            RpgCharacter player = new RpgCharacter{ HitPoints = PlayerStartingHitPoints };

            var weapons = new List<Item>
            {
                new Item { Name = "Dagger",     Cost =  8, Damage =  4, Armor = 0},
                new Item { Name = "Shortsword", Cost = 10, Damage =  5, Armor = 0},
                new Item { Name = "Warhammer",  Cost = 25, Damage =  6, Armor = 0},
                new Item { Name = "Longsword",  Cost = 40, Damage =  7, Armor = 0},
                new Item { Name = "Greataxe",   Cost = 74, Damage =  8, Armor = 0}
            };

            var armor = new List<Item>
            {
                new Item { Name = "Leather",    Cost =  13, Damage = 0, Armor = 1},
                new Item { Name = "Chainmail",  Cost =  31, Damage = 0, Armor = 2},
                new Item { Name = "Splintmail", Cost =  53, Damage = 0, Armor = 3},
                new Item { Name = "Bandedmail", Cost =  75, Damage = 0, Armor = 4},
                new Item { Name = "Platemail",  Cost = 102, Damage = 0, Armor = 5}
            };

            var rings = new List<Item>
            {
                new Item { Name="Damage +1",  Cost =  25, Damage = 1, Armor = 0},
                new Item { Name="Damage +2",  Cost =  50, Damage = 2, Armor = 0},
                new Item { Name="Damage +3",  Cost = 100, Damage = 3, Armor = 0},
                new Item { Name="Defense +1", Cost =  20, Damage = 0, Armor = 1},
                new Item { Name="Defense +2", Cost =  40, Damage = 0, Armor = 2},
                new Item { Name="Defense +3", Cost =  80, Damage = 0, Armor = 3}
            };

        }

    }

    [DebuggerDisplay("HitPoints {HitPoints},  Damage {Damage},  Armor {Armor}")]
    public class RpgCharacter
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }

    [DebuggerDisplay("{Name}:  Cost {Cost},  Damage {Damage},  Armor {Armor}")]
    public class Item
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }


}
