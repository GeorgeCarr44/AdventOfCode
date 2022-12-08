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

        public static Tree[,]? Forest { get; set; }

        public class Tree
        {
            public int Height { get; set; }
            public bool? Visible { get; set; }
            readonly int XPos;
            readonly int YPos;
            public Tree[] Neigbours { get; set; }

            public Tree(int x, int y, int height)
            {
                Height = height;
                Visible = null;
                XPos = x;
                YPos = y;
            }

            public void LookAtNeigbours()
            {
                //Out of Forest Exception
                Neigbours = new Tree[4];

                if (XPos - 1 >= 0)
                    Neigbours[0] = Forest[XPos - 1, YPos];
                if (YPos + 1 <= Forest.GetLength(0) - 1)
                    Neigbours[1] = Forest[XPos, YPos + 1];
                if (XPos + 1 <= Forest.GetLength(1) - 1)
                    Neigbours[2] = Forest[XPos + 1, YPos];
                if (YPos - 1 >= 0)
                    Neigbours[3] = Forest[XPos, YPos - 1];
            }

            public void CheckVisible()
            {
                if(Neigbours.Any(x => x == null))
                    Visible = true;
                else if(Neigbours.Any(x => x.Visible == true && x.Height < this.Height))
                    Visible = true;
                else if(Neigbours.All(x => x.Visible != null))
                    Visible = false;
            }
        }

        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\Trees.txt");
            Part1();
            Part2();
        }

        private static void Part1()
        {
            GenerateForest();
            DrawForest();
        }

        private static void Part2()
        {

        }

        private static void GenerateForest()
        {

            int X = Input[0].Length;
            int Y = Input.Length;

            Forest = new Tree[X, Y];

            for (int x = 0; x < X; x++)
            {
                int[] currentLineCharArray = Input[x].Select(x => Int32.Parse(x.ToString())).ToArray();
                for (int y = 0; y < Y; y++)
                {
                    Forest[x, y] = new Tree(x, y, Convert.ToInt32(currentLineCharArray[y]));
                }
            }

            foreach (var tree in Forest)
            {
                tree.LookAtNeigbours();
            }

            for (int i = 0; i < 100; i++)
            {
                foreach (var tree in Forest)
                { 
                    tree.CheckVisible();
                }

            }

            int count = 0;

            foreach (var tree in Forest)
            {
                if(tree.Visible == true)
                    count++;
            }
            Console.WriteLine(count);
        }


        private static void DrawForest()
        {

            int X = Input[0].Length;
            int Y = Input.Length;

            for (int x = 0; x < X; x++)
            {
                string line = "";
                var currentLineCharArray = Input[x].ToCharArray();
                for (int y = 0; y < Y; y++)
                {
                    line += Forest[x, y].Height;
                    if(Forest[x, y].Visible == true)
                        line += ' ';
                    else
                        line +=  '!';
                    line += ' ';
                }
                Console.WriteLine(line);
            }
        }



    }
}
