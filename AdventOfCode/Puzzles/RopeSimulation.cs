using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class RopeSimulation
    {
        [Flags]
        enum States
        {
            None = 0,
            Head = 1,
            Tail = 2,
            TailVisited = 4,
            Start = 8
        }

        public static string[] Input { get; set; }

        private static int startX;
        private static int startY;

        public static void Run()
        {
            Part1();
        }

        private static void Part1()
        {



            int[,] matrix = CreateMatrix();

            //find the starting position and stack the rope there
            matrix[startX, startY] = (int)States.Start + (int)States.Tail + (int)States.TailVisited + (int)States.Head;

            //keep reference to head and tail position so we dont have to find it again

            //loop instructiions

            //move the Head

            //check distance between head and tail

            //move tail if needed
            //mark Visited
        }

        private static int[,] CreateMatrix()
        {
            //Get the size of the array
            //In both +/- x and y

            //read instructions
            Input = File.ReadAllLines(@"Inputs\RopeSimulation.txt");

            //determine the required matrix size
            int x = 0;
            int y = 0;

            int xMax = 0;
            int yMax = 0;
            int xMin = 0;
            int yMin = 0;

            foreach (var line in Input)
            {
                var s = line.Split(" ");
                var direction = s[0];
                var move = Convert.ToInt32(s[1]);
                switch (direction)
                {
                    case "U":
                        y += move;
                        break;
                    case "R":
                        x += move;
                        break;
                    case "D":
                        y -= move;
                        break;
                    case "L":
                        x -= move;
                        break;
                }

                if (xMax < x)
                    xMax = x;
                if (yMax < y)
                    yMax = y;
                if (xMin > x)
                    xMin = x;
                if (yMin > y)
                    yMin = y;

            }

            startX = -xMin;
            startY = -yMin;

            //Create the int array
            return new int[xMax - xMin, yMax - yMin];
        }
    }
}
