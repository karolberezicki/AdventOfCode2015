using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day15
{
    public class Program15
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            List<string> instructions = source.Split('\n').ToList();

            var ingridients = instructions.Select(i => new Ingredient(i)).ToList();

            Console.ReadKey();
        }
    }
}