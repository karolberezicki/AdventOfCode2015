using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day08
{
    public class Program08
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> stringLiterals = source.Split('\n').ToList();

            int countNonValueCharacters = stringLiterals.Select(CountNonValueCharacters).Sum();
            int encodedStringLiteralLength = stringLiterals.Select(EncodedStringLiteralLength).Sum();

            Console.WriteLine("Part one (count non value chars) = {0}", countNonValueCharacters);
            Console.WriteLine("Part two (count extra chars used to encoding) = {0}", encodedStringLiteralLength);

            Console.ReadLine();
        }

        public static int CountNonValueCharacters(string stringLiteral)
        {
            int countNonValue = 0;

            for (int i = 0; i < stringLiteral.Length; i++)
            {
                char currentChar = stringLiteral[i];

                if (currentChar == '\\')
                {
                    char nextChar = stringLiteral[i + 1];
                    if (nextChar == '\\' || nextChar == '\"')
                    {
                        i++;
                        countNonValue++;
                    }
                    else if (nextChar == 'x')
                    {
                        countNonValue += 3;
                        i += 3;
                    }
                }
            }
            return countNonValue + 2;
        }

        public static int EncodedStringLiteralLength(string stringLiteral)
        {
            int countNonValue = 0;

            for (int i = 0; i < stringLiteral.Length; i++)
            {
                char currentChar = stringLiteral[i];

                if (currentChar == '\\')
                {
                    char nextChar = stringLiteral[i + 1];
                    if (nextChar == '\\' || nextChar == '\"')
                    {
                        i++;
                        countNonValue += 2;
                    }
                    else if (nextChar == 'x')
                    {
                        i += 3;
                        countNonValue += 1;
                    }
                }
            }
            return countNonValue + 4;
        }

    }


}
