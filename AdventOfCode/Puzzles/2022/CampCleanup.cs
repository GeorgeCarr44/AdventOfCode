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
                Input.Add(new string[] { pair[0], pair[1] });
            }
        }

        private static void Part1()
        {
            int fullContain= 0;

            foreach (var pair in Input)
            {
                int[]? first = pair[0].Split("-")?.Select(Int32.Parse)?.ToArray();
                int[]? second = pair[1].Split("-")?.Select(Int32.Parse)?.ToArray();

                if(first != null && second != null)
                {
                    if (first[0] >= second[0] && first[1] <= second[1] || second[0] >= first[0] && second[1] <= first[1])
                    {
                        fullContain++;
                    }
                
                }
            }

            Console.WriteLine("Part 1");
            Console.WriteLine(fullContain);
        }

        private static void Part2()
        {
            int contain = 0;

            foreach (var pair in Input)
            {
                int[]? f = pair[0].Split("-")?.Select(Int32.Parse)?.ToArray();
                int[]? s = pair[1].Split("-")?.Select(Int32.Parse)?.ToArray();

                if (f != null && s != null)
                {
                    if (f[0] <= s[0] && f[1] >= s[0] || f[0] <= s[1] && f[1] >= s[1]
                        || s[0] <= f[0] && s[1] >= f[0] || s[0] <= f[1] && s[1] >= f[1])
                    {
                        contain++;
                    }

                }
            }

            Console.WriteLine("Part 2");
            Console.WriteLine(contain);
        }
    }
}
