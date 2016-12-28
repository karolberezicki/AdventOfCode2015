using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day06
{
    public class Program06
    {
        public static void Main()
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            List<string> commands = source.Split('\n').ToList();

            // Part One

            bool[,] lightsArray = new bool[1000, 1000];

            foreach (string stringCommand in commands)
            {
                Command command = ParseCommand(stringCommand);
                ExecuteCommand(command, ref lightsArray);
            }

            int lightsOnCount = 0;

            for (int i = 0; i < lightsArray.GetLength(0); i++)
            {
                for (int j = 0; j < lightsArray.GetLength(1); j++)
                {

                    if (lightsArray[i, j])
                    {
                        lightsOnCount++;
                    }
                }
            }

            // Part Two

            int[,] lightsWithBrightnessArray = new int[1000, 1000];

            foreach (string stringCommand in commands)
            {
                Command command = ParseCommand(stringCommand);
                ExecuteCommandBrightness(command, ref lightsWithBrightnessArray);
            }

            long totalBrightness = 0;

            for (int i = 0; i < lightsWithBrightnessArray.GetLength(0); i++)
            {
                for (int j = 0; j < lightsWithBrightnessArray.GetLength(1); j++)
                {

                    totalBrightness += lightsWithBrightnessArray[i, j];
                }
            }

            Console.WriteLine("Total Lights on = {0}", lightsOnCount);
            Console.WriteLine("Total Brightness on = {0}", totalBrightness);

            Console.ReadLine();
        }

        public static Command ParseCommand(string stingCommand)
        {
            Command command = new Command();

            if (stingCommand.Contains("turn on"))
            {
                command.Instruction = Instruction.TrunOn;
            }
            else if (stingCommand.Contains("turn off"))
            {
                command.Instruction = Instruction.TrunOff;
            }
            else
            {
                command.Instruction = Instruction.Toggle;
            }

            string[] coor = RemoveExtraText(stingCommand.Replace("through", ",")).Split(',');

            command.FromX = int.Parse(coor[0]);
            command.FromY = int.Parse(coor[1]);
            command.ToX = int.Parse(coor[2]);
            command.ToY = int.Parse(coor[3]);
            return command;
        }

        public static string RemoveExtraText(string value)
        {
            string allowedChars = "01234567890.,";
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }

        public static void ExecuteCommand(Command command, ref bool[,] array)
        {

            for (int i = command.FromX; i <= command.ToX; i++)
            {
                for (int j = command.FromY; j <= command.ToY; j++)
                {
                    switch (command.Instruction)
                    {
                        case Instruction.TrunOn:
                            array[i, j] = true;
                            break;
                        case Instruction.TrunOff:
                            array[i, j] = false;
                            break;
                        case Instruction.Toggle:
                            array[i, j] = !array[i, j];
                            break;
                    }
                }
            }
        }

        public static void ExecuteCommandBrightness(Command command, ref int[,] array)
        {

            for (int i = command.FromX; i <= command.ToX; i++)
            {
                for (int j = command.FromY; j <= command.ToY; j++)
                {
                    switch (command.Instruction)
                    {
                        case Instruction.TrunOn:
                            array[i, j] += 1;
                            break;
                        case Instruction.TrunOff:
                            array[i, j] = Math.Max(0, array[i, j] - 1);
                            break;
                        case Instruction.Toggle:
                            array[i, j] += 2;
                            break;
                    }
                }
            }
        }

    }

    public enum Instruction
    {
        TrunOn,
        TrunOff,
        Toggle
    }

    public class Command
    {
        public Instruction Instruction { get; set; }
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }
    }


}
