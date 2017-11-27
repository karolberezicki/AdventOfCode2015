using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day18
{
    public class Program18
    {
        public static void Main()
        {

            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            var input = source.Split('\n').Select(c => c.Select(b => b == '#').ToArray()).ToArray();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {

                }
            }

        }
    }
}
