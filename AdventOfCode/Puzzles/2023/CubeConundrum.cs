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
    }
}
