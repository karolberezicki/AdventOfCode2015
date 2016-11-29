using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day07
{
    public class Program_07
    {

        public static void Main(string[] args)
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> circuits = source.Split('\n').ToList();

            ushort partOneResult = CalculateOutput(circuits);

            string bInput = circuits.First(p => p.Split(' ')[2] == "b");

            source = source.Replace(bInput, string.Format("{0} -> b", partOneResult));  //override wire b to signal a
            circuits = source.Split('\n').ToList();
            ushort partTwoResult = CalculateOutput(circuits);

            Console.WriteLine("Part one result {0}", partOneResult);
            Console.WriteLine("Part two result {0}", partTwoResult);
            Console.ReadLine();

        }

        private static ushort CalculateOutput(List<string> circuits)
        {
            Dictionary<string, ushort> knownValues = new Dictionary<string, ushort>();
            while (!knownValues.ContainsKey("a"))
            {
                foreach (string item in circuits)
                {
                    string[] circuitPart = item.Split(' ');


                    if (circuitPart[1] == "->")
                    {
                        if (knownValues.ContainsKey(circuitPart[0]))
                        {
                            knownValues[circuitPart[2]] = knownValues[circuitPart[0]];
                        }
                        else if (ushort.TryParse(circuitPart[0], out ushort value))
                        {
                            knownValues[circuitPart[2]] = value;
                        }
                        continue;
                    }
                    if (circuitPart[1] == "RSHIFT")
                    {
                        if (knownValues.ContainsKey(circuitPart[0]))
                        {
                            knownValues[circuitPart[4]] = (ushort)(knownValues[circuitPart[0]] >> int.Parse(circuitPart[2]));
                        }
                        continue;
                    }
                    if (circuitPart[1] == "LSHIFT")
                    {
                        if (knownValues.ContainsKey(circuitPart[0]))
                        {
                            knownValues[circuitPart[4]] = (ushort)(knownValues[circuitPart[0]] << int.Parse(circuitPart[2]));
                        }
                        continue;
                    }
                    if (circuitPart[0] == "NOT")
                    {
                        if (knownValues.ContainsKey(circuitPart[1]))
                        {
                            knownValues[circuitPart[3]] = (ushort)(ushort.MaxValue - knownValues[circuitPart[1]]);
                        }
                        continue;
                    }

                    if (circuitPart[1] == "AND")
                    {
                        if (knownValues.ContainsKey(circuitPart[0]) && knownValues.ContainsKey(circuitPart[2]))
                        {
                            knownValues[circuitPart[4]] = (ushort)(knownValues[circuitPart[0]] & knownValues[circuitPart[2]]);
                        }
                        else if (int.TryParse(circuitPart[0], out int leftOperand) && knownValues.ContainsKey(circuitPart[2]))
                        {
                            knownValues[circuitPart[4]] = (ushort)(leftOperand & knownValues[circuitPart[2]]);
                        }
                        if (knownValues.ContainsKey(circuitPart[0]) && int.TryParse(circuitPart[2], out int rightOperand))
                        {
                            knownValues[circuitPart[4]] = (ushort)(knownValues[circuitPart[2]] & rightOperand);
                        }
                        continue;
                    }

                    if (circuitPart[1] == "OR")
                    {
                        if (knownValues.ContainsKey(circuitPart[0]) && knownValues.ContainsKey(circuitPart[2]))
                        {
                            knownValues[circuitPart[4]] = (ushort)(knownValues[circuitPart[0]] | knownValues[circuitPart[2]]);
                        }
                        else if (int.TryParse(circuitPart[0], out int leftOperand) && knownValues.ContainsKey(circuitPart[2]))
                        {
                            knownValues[circuitPart[4]] = (ushort)(leftOperand | knownValues[circuitPart[2]]);
                        }
                        if (knownValues.ContainsKey(circuitPart[0]) && int.TryParse(circuitPart[2], out int rightOperand))
                        {
                            knownValues[circuitPart[4]] = (ushort)(knownValues[circuitPart[2]] | rightOperand);
                        }
                        continue;
                    }
                }
            }

            return knownValues["a"];
        }
    }
}
