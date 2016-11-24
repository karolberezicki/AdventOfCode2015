﻿using System;
using System.IO;


namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            int countUp = source.Length - source.Replace("(", "").Length;
            int countDown = source.Length - source.Replace(")", "").Length;

            Console.WriteLine(countUp - countDown);

            int position = 0;
            int level = 0;
            foreach (char instruction in source.ToCharArray())
            {
                position++;


                if (instruction == '(')
                {
                    level++;
                }
                else
                {
                    level--;
                }

                if (level<0)
                {
                    break;
                }

            }
            Console.WriteLine(position);

            Console.ReadLine();
        }
    }
}
