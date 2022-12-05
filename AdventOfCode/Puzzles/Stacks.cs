using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class Stacks
    {

        public static string[] Input { get; set; }
        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\Stacks.txt");
            ReadStacks();
            ReadOrders();
            Part1();
            Part2();
        }

        private static void ReadOrders()
        {

        }

        private static void ReadStacks()
        {
            //Get just the stacks?
            foreach (var line in Input)
            {
                if (line == String.Empty)
                    break;

                //Read every 4th char until the end of the line?
                for (int i = 1; i < line.Length; i += 4)
                {
                    var charArray = line.ToCharArray();
                    Console.Write($"[{charArray[i]}] ");
                }
                Console.WriteLine();
            }

        }

        private static void Part1()
        {

        }

        private static void Part2()
        {

        }
    }
}
