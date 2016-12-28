using System;
using System.IO;


namespace day01
{
    class Program01
    {
        static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            int countUp = source.Length - source.Replace("(", "").Length;
            int countDown = source.Length - source.Replace(")", "").Length;

            Console.WriteLine(countUp - countDown);

            int position = 0;
            int level = 0;
            foreach (char instruction in source)
            {
                position++;
                int levelChange = instruction == '(' ? 1 : -1;
                level += levelChange;

                if (level < 0)
                {
                    break;
                }

            }
            Console.WriteLine(position);

            Console.ReadLine();
        }
    }
}
