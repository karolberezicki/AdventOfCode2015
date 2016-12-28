using System;
using System.Security.Cryptography;
using System.Text;

namespace day04
{
    class Program04
    {
        static void Main()
        {
            string source = "bgvyzdsv";

            int iterator = 0;
            int secretNumber5 = 0;
            int secretNumber6 = 0;

            bool secretNumber5Found = false;
            bool secretNumber6Found = false;

            while (true)
            {
                string hash = CalculateMd5Hash(source + iterator.ToString());
                if (hash.StartsWith("00000") && !secretNumber5Found)
                {
                    secretNumber5 = iterator;
                    secretNumber5Found = true;
                }

                if (hash.StartsWith("000000") && !secretNumber6Found)
                {
                    secretNumber6 = iterator;
                    secretNumber6Found = true;
                }

                if (secretNumber5Found && secretNumber6Found)
                {
                    break;
                }

                iterator++;
            }

            Console.WriteLine("Secret number 5 is {0}", secretNumber5);
            Console.WriteLine("Secret number 6 is {0}", secretNumber6);

            Console.ReadLine();
        }

        public static string CalculateMd5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
