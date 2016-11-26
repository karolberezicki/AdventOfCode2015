using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day02
{
    class Program_02
    {
        static void Main(string[] args)
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);

            int sumOfNeededPaper = 0;
            int sumOfNeededRibbon = 0;

            List<string> presents = source.Split('\n').ToList();


            foreach (string present in presents)
            {
                List<int> presentDimensions = present.Split('x').Select(dimension => int.Parse(dimension)).ToList();
                int length = presentDimensions[0];
                int width  = presentDimensions[1];
                int height = presentDimensions[2];

                int lwSide = length * width;
                int whSide = width * height;
                int hlSide = height * length;

                presentDimensions.Sort();
                int extra = presentDimensions[0]; // take min value

                int paperForPresent = 2 * (lwSide + whSide + hlSide) + extra;
                sumOfNeededPaper += paperForPresent;

                int ribbon = 2 * (presentDimensions[0] + presentDimensions[1]);
                int bow = length * width * height;

                sumOfNeededRibbon += (ribbon + bow);

            }

            Console.WriteLine("Needed paper = {0}",sumOfNeededPaper);
            Console.WriteLine("Needed ribbon = {0}", sumOfNeededRibbon);
            Console.ReadLine();


        }
    }
}
