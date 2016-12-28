using System;
using System.Collections.Generic;
using System.Linq;

namespace day11
{
    public class Program11
    {
        public static void Main()
        {
            const string oldPassword = "vzbxkghb";
            string newPassword = GetNewPassword(oldPassword);
            string anotherPassword = GetNewPassword(newPassword);

            Console.WriteLine(newPassword);
            Console.WriteLine(anotherPassword);
            Console.ReadLine();
        }


        public static string GetNewPassword(string oldPassword)
        {
            string newPassword = oldPassword;
            do
            {
                newPassword = IncrementPassword(newPassword);
            } while (!IsSecurePassword(newPassword));

            return newPassword;
        }

        public static bool IsSecurePassword(string input)
        {
            return (IncludesSeries(input) && DoesntIncludeForbidden(input) && IncludesAtLeastTwoPairs(input));
        }

        public static bool IncludesSeries(string input)
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] + 1 == input[i + 1] && input[i] + 2 == input[i + 2])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool DoesntIncludeForbidden(string input)
        {
            List<char> forbidden = new List<char> { 'i', 'o', 'l' };

            return !input.Any(x => forbidden.Contains(x));
        }

        public static bool IncludesAtLeastTwoPairs(string input)
        {
            int countPairs = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    countPairs++;
                    i++;
                }

            }

            return countPairs >= 2;
        }

        public static string IncrementPassword(string oldPassword)
        {
            const char zChar = 'z';
            const char aChar = 'a';

            bool carry = true;
            char[] password = Reverse(oldPassword).ToCharArray();

            for (int i = 0; i < password.Length; i++)
            {

                if (carry)
                {
                    password[i] = (char)(password[i] + 1);
                }

                if (password[i] > zChar)
                {
                    carry = true;
                    password[i] = aChar;
                }
                else
                {
                    carry = false;
                }
            }

            return Reverse(string.Join("", password));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
