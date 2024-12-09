using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2024
{
    static class MullItOver
    {
        private static string[] Rows { get; set; }

        public static void Run()
        {
            ReadInput(@"Inputs\2024\MullItOver.txt");
            Part1();
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
            
        }

        private static void ReadInput(string input)
        {
            Rows = File.ReadAllLines(input);
        }

    }
}
