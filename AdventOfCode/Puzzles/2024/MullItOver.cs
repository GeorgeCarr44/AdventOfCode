using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2024
{
    static class MullItOver
    {
        private static string[] Rows { get; set; }
        private static string RunningCommand { get; set; }
        private static string CaptureGroup { get; set; }

        public static void Run()
        {
            ReadInput(@"Inputs\2024\MullItOver.txt");
            Part2();
        }

        private static void Part1()
        {
            int mul = 0;
            // Sort Lists
            foreach (var row in Rows)
            {
                bool skipFirst = !row.StartsWith("mul(");

                string[] instructions = row.Split("mul(");
                foreach (var instruction in instructions)
                {
                    if (skipFirst)
                    {
                        skipFirst = false;
                        continue;
                    }

                    var numbersToBeMultiplied = instruction.Split(',');
                    if (numbersToBeMultiplied.Length > 1)
                    {
                        if (int.TryParse(numbersToBeMultiplied[0], out int first) && int.TryParse(new String(numbersToBeMultiplied[1].TakeWhile(Char.IsDigit).ToArray()), out int second))

                            if (numbersToBeMultiplied[1].ToCharArray().Length > second.ToString().Length)
                        {
                            char trailingBracket = numbersToBeMultiplied[1].ToCharArray()[second.ToString().Length];
                            if (trailingBracket == ')')
                                mul += Convert.ToInt32(numbersToBeMultiplied[0]) * Convert.ToInt32(second);
                        }
                    }
                }
            }

            Console.WriteLine("Total: " + mul);

        }

        private static void Part2()
        {
            bool mulEnabled = true;
            bool captureNumber = false;
            int? firstNumber = null;
            int? secondNumber = null;


            foreach (var row in Rows)
            { 
                RunningCommand = string.Empty;
                CaptureGroup = string.Empty;
                foreach (var currentChar in row.ToCharArray())
                {
                    if (captureNumber)
                    {

                        if (Char.IsNumber(currentChar))
                        {
                            CaptureGroup += currentChar;
                        }
                        else if (currentChar == ',')
                        {
                            if (RunningCommand == "mul_First_Param")



                            if (firstNumber.HasValue)
                            {
                                firstNumber += currentChar;
                            }
                        }
                        else
                        {
                            // Invalid format fail out.
                            RunningCommand = string.Empty;
                            CaptureGroup = string.Empty;
                        }
                    }
                    else
                    {
                        if (CheckCommand(currentChar, "mul(") && mulEnabled)
                        {
                            // Look at next should be (
                            captureNumber = true;
                            // look at next 
                        }

                        if (CheckCommand(currentChar, "do()"))
                            mulEnabled = true;
                        if (CheckCommand(currentChar, "don't()"))
                            mulEnabled = false;
                    }
                }
                
            }
        }

        private static bool CheckCommand(char currentChar, string command)
        {
            if (currentChar == command.ToCharArray()[RunningCommand.Length])
            {
                RunningCommand += currentChar;
            }

            if (RunningCommand == command)
            {
                RunningCommand = string.Empty;
                return true;
            }
            return false;
        }

        private static void ReadInput(string input)
        {
            Rows = File.ReadAllLines(input);
        }

    }
}
