using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class Stacks
    {


        static List<Stack<string>> crates = new List<Stack<string>>();

        public static string[] instructions { get; set; }

        public static void Run()
        {
            Setup();
            Part1();
            
            Setup();
            Part2();
        }

        private static void Setup()
        {

            crates = new List<Stack<string>>();
            var input = File.ReadAllLines(@"Inputs\Stacks.txt");

            //Finds the height by finding where the numbers are
            int stacksHeight = Array.FindIndex(input, line => line.StartsWith(" 1"));


            // Get the stacks width, gets the last string from the array and converts in to int
            int stacksWidth = Convert.ToInt32(input[stacksHeight].Trim().Split("   ").Last());


            var cratesStartingStack = input.Take(stacksHeight).ToArray().Reverse();
            instructions = Array.FindAll(input, line => line.StartsWith("move"));

            for (int i = 0; i < stacksWidth; i++)
            {
                crates.Add(new Stack<string>());
            }

            foreach (var line in cratesStartingStack)
            {
                int lineCounter = 0;
                for (int j = 1; j <= line.Length; j += 4)
                {
                    var crate = line.ElementAt(j).ToString();
                    if (!string.IsNullOrWhiteSpace(crate))
                    {
                        crates.ElementAt(lineCounter).Push(crate);
                    }
                    lineCounter++;
                }
            }
        }

        private static void Part1()
        {
            foreach (var line in instructions)
            {
                var moves = line.Trim().Split(' ');
                int cratesToMove = int.Parse(moves.ElementAt(1));
                int pickFromStack = int.Parse(moves.ElementAt(3)) - 1;
                int placeStack = int.Parse(moves.ElementAt(5)) - 1;

                while (cratesToMove > 0)
                {
                    var crate = crates.ElementAt(pickFromStack).Pop();
                    crates.ElementAt(placeStack).Push(crate);
                    cratesToMove--;
                }
            }

            Console.WriteLine("--- Part 1 ---");
            Console.WriteLine("Top Crates:");

            foreach (var stack in crates)
            {
                Console.Write(stack.Peek());
            }
        }

        private static void Part2()
        {
            foreach (var line in instructions)
            {
                var moves = line.Trim().Split(' ');
                int cratesToMove = int.Parse(moves.ElementAt(1));
                int pickFromStack = int.Parse(moves.ElementAt(3)) - 1;
                int placeStack = int.Parse(moves.ElementAt(5)) - 1;

                Stack<string> storage = new Stack<string>();

                while (cratesToMove > 0)
                {
                    var crate = crates.ElementAt(pickFromStack).Pop();
                    storage.Push(crate);
                    cratesToMove--;
                }

                while (storage.Count > 0)
                {
                    var crate = storage.Pop();
                    crates.ElementAt(placeStack).Push(crate);
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- Part 2 ---");
            Console.WriteLine("Top Crates:");

            foreach (var stack in crates)
            {
                Console.Write(stack.Peek());
            }
        }
    }
}
