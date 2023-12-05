using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class Calories
    {


        public static void Run()
        {
            string[] input = File.ReadAllLines(@"Inputs\Calories.txt");

            int tmpCalories = 0;

            List<int> Elves = new List<int>();

            foreach (var line in input)
            {
                if(line == string.Empty)
                {
                    Elves.Add(tmpCalories);
                    tmpCalories = 0;
                }
                else
                {
                    tmpCalories += Int32.Parse(line);
                }
            }
            //Last one as we dont end with a line break

            if(tmpCalories != 0)
                Elves.Add(tmpCalories);
            Console.WriteLine("Max:");
            Console.WriteLine(Elves.Max());

            Console.WriteLine("Top 3:");
            int topThree = 0;
            Elves.Sort();
            Elves.Reverse();
            for (int i = 0; i < 3; i++)
            {
                topThree += Elves[i];
            }

            Console.WriteLine(topThree);

        }
    }
}
