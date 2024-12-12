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
        private static string CommandBuffer { get; set; }
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
            int total = 0;


            foreach (var row in Rows)
            { 

                CommandBuffer = string.Empty;
                CaptureGroup = string.Empty;
                foreach (var currentChar in row.ToCharArray())
                {
                    // Capturing a parameter
                    if (captureNumber)
                    {
                        // Should be a number
                        if (Char.IsNumber(currentChar))
                        {
                            CaptureGroup += currentChar;
                        }
                        // If its not a number then it could be the end of first param and mark next param
                        else if (currentChar == ',' && CommandBuffer == "mul_First_Param")
                        {
                            // Store first param
                            firstNumber = Int32.Parse(CaptureGroup);
                            // Clear Capture Group
                            CaptureGroup = string.Empty;
                            // Set Command buffer to method_position_param
                            CommandBuffer = "mul_Second_Param";
                        }
                        // If end of the parameters
                        else if (currentChar == ')' && CommandBuffer == "mul_Second_Param")
                        {
                            // Only support 2 params so set second num
                            secondNumber = Int32.Parse(CaptureGroup);
                            // Clear capture group
                            CaptureGroup = string.Empty;
                            // No longer capturing numbers
                            captureNumber = false;
                            // Clear command buffer as reached end of command
                            CommandBuffer = string.Empty;
                            // Perform mult and increment total
                            total += firstNumber.Value * secondNumber.Value;

                        }
                        else
                        {
                            // Invalid format fail out and reset buffers and capture groups
                            CommandBuffer = string.Empty;
                            CaptureGroup = string.Empty;
                            captureNumber = false;
                        }
                    }
                    else
                    {
                        // Store the Command Buffer before it is expanded
                        var tmpRunningCommand = CommandBuffer.Length;

                        // Check the Command Buffer for the multiply command
                        if (CheckCommand(currentChar, "mul(") && mulEnabled)
                        {
                            // Set Capture Group to true as we are expecting a parameter input
                            captureNumber = true;
                            // Set Command Buffer to method_position_param
                            CommandBuffer = "mul_First_Param";
                            continue;
                        }

                        // Check the Command Buffer for the do command
                        if (CheckCommand(currentChar, "do()"))
                        {
                            // Enable multiplication
                            mulEnabled = true;
                            continue;
                        }
                        if (CheckCommand(currentChar, "don't()"))
                        {
                            // Disable multiplication
                            mulEnabled = false;
                            continue;
                        }


                        // Reset the buffer command if a match was not found once it had been started
                        if(CommandBuffer.Length == tmpRunningCommand)
                            CommandBuffer = string.Empty;
                    }
                }
                
            }

            Console.WriteLine(total);
        }

        /// <summary>
        /// Checks the Command Buffer Against Command
        /// Increments the Buffer with the next char if found
        /// </summary>
        /// <param name="currentChar"></param>
        /// <param name="command"></param>
        /// <returns>Returns true if the command buffer matches the command and should be returned</returns>
        private static bool CheckCommand(char currentChar, string command)
        {
            // Make sure that our Command Buffer isnt currently storing a command that has a longer method name than the one we are checking
            if (command.Length > CommandBuffer.Length)
            {
                // If the next char in the array matches the next char in the potential command then include this in the command buffer
                if (currentChar == command.ToCharArray()[CommandBuffer.Length])
                {
                    CommandBuffer += currentChar;
                }

                // If the Command buffer equals the command then empty the buffer and return true so this command can be ran
                if (CommandBuffer == command)
                {
                    CommandBuffer = string.Empty;
                    return true;
                }
            }
            return false;
        }

        private static void ReadInput(string input)
        {
            Rows = File.ReadAllLines(input);
        }

    }
}
