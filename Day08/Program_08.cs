using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day08
{
    public class Program_08
    {
        public static void Main(string[] args)
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> stringLiterals = source.Split('\n').ToList();


            int countNonValueCharacters = 0;

            foreach (string stringLiteral in stringLiterals)
            {
                countNonValueCharacters += CountNonValueCharacters(stringLiteral);
            }

            Console.WriteLine("Part one (count non value chars) = {0}", countNonValueCharacters);
            Console.ReadLine();
        }


        public static int CountNonValueCharacters(string stringLiteral)
        {
            int countValueChars = 0;

            for (int i = 0; i < stringLiteral.Length; i++)
            {
                char currentChar = stringLiteral[i];

                if (currentChar == '\\')
                {
                    char nextChar = stringLiteral[i + 1];
                    if (nextChar == '\\' || nextChar == '\"')
                    {
                        i++;
                    }
                    else if (nextChar == 'x')
                    {
                        i += 3;
                    }
                }
                countValueChars++;
            }
            return stringLiteral.Length - countValueChars + 2;
        }
    }


}
