using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class Trees
    {
        public static string[] Input { get; set; }

        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\Trees.txt");

            int visibleTrees = 0;
            int scenicScore = 0;
            for (int x = 0; x < Input.Length; x++)
            {
                for (int y = 0; y < Input[x].Length; y++)
                {
                    if (CheckVisible(x, y))
                        visibleTrees++;

                    int currentScore = CheckScenicScore(x, y);
                    if (currentScore > scenicScore)
                        scenicScore = currentScore;
                }
            }
            Console.WriteLine("--- Part 1 ---");
            Console.WriteLine(visibleTrees);
            Console.WriteLine("--- Part 2 ---");
            Console.WriteLine(scenicScore);
        }

        private static bool CheckVisible(int x, int y)
        {
            //returns first true
            var startValue = Input[x][y];

            return IsVisible(x, y, -1, 0, startValue) || IsVisible(x, y, 0, 1, startValue) || IsVisible(x, y, 1, 0, startValue) || IsVisible(x, y, 0, -1, startValue);
        }

        private static bool IsVisible(int x, int y, int xChange, int yChange, char startValue)
        {
            //Edge Pieces
            if (x == 0 || y == 0 || x == Input[x].Length - 1 || y == Input.Length - 1)
            {
                return true;
            }

            //Cant be seen from the north
            //Cant be out of range as returns when edge piece
            if (startValue <= Input[x + xChange][y + yChange])
            {
                return false;
            }

            return IsVisible(x + xChange, y + yChange, xChange, yChange, startValue);
        }

        private static int CheckScenicScore(int x, int y)
        {
            //returns first true
            var startValue = Input[x][y];

            //If any tree is right on the edge the score will be 0 its multiplied
            return ScenicScore(x, y, -1, 0, startValue) * ScenicScore(x, y, 0, 1, startValue) * ScenicScore(x, y, 1, 0, startValue) * ScenicScore(x, y, 0, -1, startValue);
        }

        private static int ScenicScore(int x, int y, int xChange, int yChange, char startValue)
        {
            //If its looking out of bounds
            if (x + xChange == -1 || y + yChange == -1 || x + xChange == Input[x].Length || y + yChange == Input.Length)
            {
                return 0;
            }

            //Cant be seen from the north
            //Cant be out of range as returns when edge piece
            if (startValue <= Input[x + xChange][y + yChange])
            {
                return 1;
            }

            return 1 + ScenicScore(x + xChange, y + yChange, xChange, yChange, startValue);
        }
    }
}
