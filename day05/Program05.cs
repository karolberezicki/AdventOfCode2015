using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day05
{
    public class Program05
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> strings = source.Split('\n').ToList();

            int niceStringsCount = strings.Count(IsNiceString);
            int realyNiceStringsCount = strings.Count(IsRealyNiceString);

            Console.WriteLine("Nice string count = {0}", niceStringsCount);
            Console.WriteLine("Realy nice string count = {0}", realyNiceStringsCount);
            Console.ReadLine();
        }


        public static bool IsNiceString(string value)
        {
            List<string> naughties = new List<string> { "ab", "cd", "pq", "xy" };

            if (naughties.Any(value.Contains))
            {
                return false;
            }

            List<char> valuesList = value.ToCharArray().ToList();

            List<char> aeiou = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<char> vowelsInValue = valuesList.Where(v => aeiou.Contains(v)).ToList();

            if (vowelsInValue.Count < 3)
            {
                return false;
            }

            for (int i = 1; i < valuesList.Count; i++)
            {
                if (valuesList[i] == valuesList[i - 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsRealyNiceString(string value)
        {
            bool hasPairWithoutOverlaping = false;
            bool hasRepeatLetterWithOneLetterSpacing = false;


            List<char> v = value.ToCharArray().ToList();

            for (int i = 0; i < v.Count; i++)
            {
                for (int j = i + 2; j < v.Count - 1; j++)
                {
                    if (v[i] == v[j] && v[i + 1] == v[j + 1])
                    {
                        hasPairWithoutOverlaping = true;
                        break;
                    }
                }
                // don't look further
                if (hasPairWithoutOverlaping)
                {
                    break;
                }
            }

            for (int i = 1; i < v.Count - 1; i++)
            {
                if (v[i - 1] == v[i + 1])
                {
                    hasRepeatLetterWithOneLetterSpacing = true;
                    break;
                }
            }

            return hasPairWithoutOverlaping && hasRepeatLetterWithOneLetterSpacing;
        }
    }
}
