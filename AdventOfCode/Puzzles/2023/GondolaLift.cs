using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{

    static class GondolaLift
    {
        public static char[,] Matrix { get; set; }
        public static char[,] tmpMatrix { get; set; }

        public static void Run()
        {
            ReadInput(@"Inputs\GondolaLift.txt");
            Part1();
            PrintMatrix();
        }
        private static void ReadInput(string input)
        {
            var Input = File.ReadAllLines(input);

            Matrix = new char[Input[0].Length, Input.Length];
            int y = 0;
            foreach (var l in Input)
            {
                int x = 0;
                foreach (var c in l.ToCharArray())
                {
                    Matrix[x, y] = c;
                    x++;
                }
                y++;
            }
        }

        private static void Part1()
        {
            //Read top left

            //If a number?
            //add that number to memory
            //then check next in row

            int totalSum = 0;
            string currentNumber = "";
            bool partAdjacent = false;
            //Row
            for (int y = 0; y < Matrix.GetLength(1); y++)
            {
                partAdjacent = false;
                currentNumber = "";

                //Line
                for (int x = 0; x < Matrix.GetLength(0); x++)
                {
                    //Check to see the next digit is a number
                    char eval = Matrix[x, y];

                    if (Char.IsDigit(Matrix[x, y]))
                    {
                        currentNumber += Matrix[x, y].ToString();
                        if (!partAdjacent)
                        {
                            partAdjacent = CheckForAdjacentPart(x, y);
                        }
                        continue;
                    }
                    //reach the end of a number
                    else if (!String.IsNullOrEmpty(currentNumber) && partAdjacent)
                    {
                        totalSum += Convert.ToInt32(currentNumber);
                        for (int i = 1; i < currentNumber.Length + 1; i++)
                        {
                            //Matrix[x - i, y] = 'X';
                        }
                    }
                    
                    partAdjacent = false;
                    currentNumber = "";
                }

                //Before we move onto the next line
                //If we have a number stored add it
                //then clear for the 
                if (!String.IsNullOrEmpty(currentNumber) && (partAdjacent))
                {
                    
                    totalSum += Convert.ToInt32(currentNumber);
                    for (int i = 1; i < currentNumber.Length + 1; i++)
                    {
                        //Matrix[Matrix.GetLength(0) - i, y] = 'X';
                    }
                }
            }

            Console.WriteLine(totalSum);
        }

        private static bool CheckForAdjacentPart(int xin, int yin)
        {
            for (int y = yin - 1; y < yin + 2; y++)
                for (int x = xin - 1; x < xin + 2; x++)
                {
                    //if the x and y value is within the bounds
                    if (!(x < 0 || x > Matrix.GetLength(0) - 1 || y < 0 || y > Matrix.GetLength(1) - 1))
                    {
                        //If the Char is a part.
                        if (!(Char.IsDigit(Matrix[x,y]) || Matrix[x, y] == '.'))
                        {
                            return true;
                        } 
                    }
                }
            return false;
        }

        private static void Part2()
        {

        }

        private static void PrintMatrix() {
            for (int y = 0; y < Matrix.GetLength(1); y++)
            {
                for (int x = 0; x < Matrix.GetLength(0); x++)
                {
                    Console.Write(Matrix[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
