using System;
using System.Text;

namespace day10
{
    public class Program_10
    {
        public static void Main(string[] args)
        {

            string input = "1113222113";
            string output = input;

            for (int i = 0; i < 40; i++)
            {
                output = LookAndSay(output);
            }

            Console.WriteLine("Part one = {0}", output.Length);

            output = input;
            for (int i = 0; i < 50; i++)
            {
                output = LookAndSay(output);
            }

            Console.WriteLine("Part two = {0}", output.Length);

            Console.ReadLine();
        }

        public static string LookAndSay(string input)
        {
            char prevChar = input[0];
            int currentCharCount = 1;

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < input.Length; i++)
            {
                if (prevChar == input[i])
                {
                    currentCharCount++;
                }
                else
                {
                    sb.Append(currentCharCount + "" + prevChar);
                    prevChar = input[i];
                    currentCharCount = 1;
                }
            }

            sb.Append(currentCharCount + "" + prevChar);
            return sb.ToString();
        }
    }
}
