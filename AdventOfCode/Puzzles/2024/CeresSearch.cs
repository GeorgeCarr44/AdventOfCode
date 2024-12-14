using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Functions;

namespace AdventOfCode.Puzzles._2024
{
    internal static class CeresSearch
    {
        private static char[,] Matrix { get; set; }

        public static void Run()
        {
            ReadInput(@"Inputs\2024\CeresSearch.txt");
            Part1();
        }

        private static void Part1()
        {
            // Loop each line
            for (int y = 0; y < Matrix.GetLength(1); y++)
            {
                // Loop each Char
                for (int x = 0; x < Matrix.GetLength(0); x++)
                {
                    Console.Write(Matrix[x, y]);
                }
                Console.WriteLine();
                
            }
            
            
            // Check char to see if it 

        }

        private static void Part2()
        {
            
        }

        private static void ReadInput(string input)
        {
            Matrix = MatrixFunctions.CreateMatrix(input);
        }

    }
}
