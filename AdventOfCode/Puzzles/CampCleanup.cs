using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    class Pair
    {
        public string One { get; set; }
        public string Two { get; set; }

        public Pair (string o, string t)
        {
            One = o;
            Two = t;
        }
    }

    static class CampCleanup
    {

        public static List<string[]> Input { get; set; } = new List<string[]>();
        public static void Run()
        {
            
            ReadInput();

            Part1();
            Part2();
        }

        private static void ReadInput()
        {
            string[] lines = File.ReadAllLines(@"Inputs\CampCleanup.txt");

            foreach (var line in lines)
            {
                var pair = line.Split(",");
                Input.Add(new string[] { GetAssignmentArray(pair[0]), GetAssignmentArray(pair[1]) });
            }
        }

        private static string GetAssignmentArray(string assignments)
        {
            string[] startend = assignments.Split('-');

            int startInt = Int32.Parse(startend[0]);
            int endInt = Int32.Parse(startend[1]);

            return string.Join(",", Enumerable.Range(startInt,  endInt - startInt + 1));
        }

        private static void Part1()
        {
            int fullContain= 0;

            foreach (var pair in Input)
            {
                Array.Sort(pair, (x, y) => x.Length.CompareTo(y.Length));
                if(pair[1].Contains(pair[0]))
                    fullContain++;
            }

            Console.WriteLine("Full Contain");
            Console.WriteLine(fullContain);
        }

        private static void Part2()
        {
        }
    }
}
