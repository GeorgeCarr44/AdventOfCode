using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2024
{
    static class HistorianHysteria
    {
        private static List<int> ALocations { get; set; }
        private static List<int> BLocations { get; set; }

        public static void Run()
        {
            ReadInput(@"Inputs\2024\HistorianHysteria.txt");
            Part1();
            ReadInput(@"Inputs\2024\HistorianHysteria.txt");
            Part2();
        }

        private static void Part1()
        {
            // Sort Lists
            ALocations.Sort();
            BLocations.Sort();

            int totalDifference = 0;

            // Loop each line and find difference
            for (int i = 0; i < ALocations.Count; i++)
                totalDifference += Math.Abs(ALocations[i] - BLocations[i]);

            Console.WriteLine("What is the total distance between your lists: " + totalDifference);

        }

        private static void Part2()
        {
            int similarity = 0;
            for (int i = 0; i < ALocations.Count; i++)
                similarity += ALocations[i] * BLocations.Where(x => x == ALocations[i]).Count();

            Console.WriteLine("What is their similarity score: " + similarity);
        }

        private static void ReadInput(string input)
        {
            var Input = File.ReadAllLines(input);
            ALocations = new List<int>();
            BLocations = new List<int>();

            foreach (var l in Input)
            {
                var loc = l.Split(' ');
                ALocations.Add(Convert.ToInt32(loc.First()));
                BLocations.Add(Convert.ToInt32(loc.Last()));
            }
        }

    }
}
