using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class PacketMarker
    {

        public static string Input { get; set; }
        public static void Run()
        {
            Input = File.ReadAllText(@"Inputs\PacketMarker.txt");
            Console.WriteLine("--- Part 1 ---");
            LookForDistinctSubstring(Input, 4);
            Console.WriteLine("--- Part 2 ---");
            LookForDistinctSubstring(Input, 14);
        }

        private static void LookForDistinctSubstring(string input, int markerLength)
        {
            for (int i = 1; i < input.Length - markerLength; i++)
            {
                var chunk = input.Substring(i, markerLength);

                if (chunk.Distinct().Count() == markerLength)
                {
                    Console.WriteLine($"Marker Location: {i + markerLength}");
                    Console.WriteLine($"Marker: {chunk}");
                    break;
                }
            }
        }
    }
}
