using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class CubeConundrum
    {

        class Game
        {
            public int Id { get; set; }
            public int MaxRed { get; set; }
            public int MaxBlue { get; set; }
            public int MaxGreen { get; set; }

            public Game(string line) {
                var lineInfo = line.Split(':');
                Id = Convert.ToInt32(lineInfo[0].Split(' ')[1]);
                foreach (var showInfo in lineInfo[1].Split(';'))
                {
                    showInfo.Trim();
                    var groupInfo = showInfo.Split(',');
                    foreach (var item in groupInfo)
                    {
                        var i = item.Trim().Split(" ");
                        var num = Convert.ToInt32(i[0]);
                        switch ((Colour)Enum.Parse(typeof(Colour), i[1], true))
                        {
                            case Colour.Red:
                                if (MaxRed < num)
                                    MaxRed = num;
                                break;
                            case Colour.Blue:
                                if (MaxBlue < num)
                                    MaxBlue = num;
                                break;
                            case Colour.Green:
                                if (MaxGreen< num)
                                    MaxGreen = num;
                                break;
                        }
                    }
                }
            }
        }

        enum Colour
        {
            Red, 
            Blue, 
            Green
        }

        public static string[] Input { get; set; }

        private static List<Game> Games {get; set; }
        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\Cubes.txt");
            Games = new List<Game>();
            foreach (var line in Input)
            {
                Games.Add(new Game(line));
            }

            Part1();
        }

        private static void Part1()
        {

            //Red 12
            //Green 13
            //Blue 14
            int output1 = 0;
            int output2 = 0;
            foreach(var game in Games)
            {

                output2 += game.MaxRed * game.MaxGreen * game.MaxBlue;

                if(!(game.MaxRed > 12 || game.MaxGreen > 13 || game.MaxBlue > 14))
                {
                    output1 += game.Id;
                }
            }
            Console.WriteLine($"Part 1: {output1}");
            Console.WriteLine($"Part 2: {output2}");
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
