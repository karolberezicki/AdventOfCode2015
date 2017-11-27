using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day17
{
    public class Program17
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<int> containers = source.Split('\n').Select(c => int.Parse(c)).ToList();



            Console.ReadKey();
        }
    }
}
