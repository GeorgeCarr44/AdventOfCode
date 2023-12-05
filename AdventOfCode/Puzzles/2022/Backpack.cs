using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class Backpack
    {

        public static string[] Input { get; set; }
        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\Backpack.txt");
            Part1();
            Part2();
        }

        private static void Part1()
        {
            int sumPriority = 0;
            foreach (var backpack in Input)
            {
                sumPriority += LetterToNumber(AppearsInBothCompartments(backpack));
            }

            Console.WriteLine("Total common items priority:");
            Console.WriteLine(sumPriority);
        }

        private static void Part2()
        {
            int sumPriority = 0;
            for (int i = 0; i < Input.Length; i += 3)
            {
                string[] backpackArray = new string[3] {
                    Input[i],
                    Input[i + 1],
                    Input[i + 2]
                    };

                var ci = CommonItems(backpackArray);

                if(ci.Count == 1)
                    sumPriority += LetterToNumber(CommonItems(backpackArray)[0]);
            }

            Console.WriteLine("Total badge priority:");
            Console.WriteLine(sumPriority);
        }

        private static List<char> CommonItems(string[] backpacks)
        {
            List<char> commonChars = new List<char>();
            commonChars.AddRange(backpacks[0]);

            for (int i = 1; i < backpacks.Length; i++)
            {
                commonChars = commonChars.Intersect(backpacks[i]).ToList<Char>();
            }
            return commonChars;
        }

        private static char AppearsInBothCompartments(string backpack)
        {
            string firstCompartment = backpack.Substring(0, backpack.Length / 2);
            string secondCompartment = backpack.Substring(backpack.Length / 2, backpack.Length / 2);

            foreach (var item in firstCompartment.ToCharArray())
                if (secondCompartment.Contains(item))
                    return item;
            
            return char.MinValue;
        }

        private static int LetterToNumber(char letter)
        {
            int index = char.ToUpper(letter) - (char.IsLower(letter) ? 64 : 38);
            return index;
        }
    }
}
