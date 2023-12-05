using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class RockPaperScissors
    {
        enum RPS
        {
            Rock,
            Paper,
            Scissors
        }

        static Dictionary<string, RPS> InputConversion = new Dictionary<string, RPS>()
        {
            { "A", RPS.Rock },
            { "B", RPS.Paper},
            { "C", RPS.Scissors },
            { "X", RPS.Rock },
            { "Y", RPS.Paper},
            { "Z", RPS.Scissors }

        };

        enum WDL
        {
            Win,
            Draw,
            Lose
        }

        static Dictionary<string, WDL> ResponseConversion = new Dictionary<string, WDL>()
        {
            { "X", WDL.Lose },
            { "Y", WDL.Draw },
            { "Z", WDL.Win },
        };



        public static void Run()
        {
            // Using list of key value pair as there will be duplicated inputs
            List<KeyValuePair<RPS, RPS>> guide = GetInput();

            int OpponentScore = 0;
            int YourScore = 0;


            foreach (var input in guide)
            {
                Tuple<int,int> scores = CalculateScore(input.Key, input.Value);
                OpponentScore += scores.Item1;
                YourScore += scores.Item2;
            }

            Console.WriteLine("Your score");
            Console.WriteLine(YourScore);
            Console.WriteLine("Your opponent score");
            Console.WriteLine(OpponentScore);
        }

        private static Tuple<int,int> CalculateScore(RPS Player1, RPS Player2)
        {
            int Score1 = 0;
            int Score2 = 0;

            switch (Player1)
            {
                case RPS.Rock:
                    Score1 += 1;
                    switch (Player2)
                    {
                        case RPS.Rock:
                            Score2 += 1;
                            Score1 += 3;
                            Score2 += 3;
                            break;
                        case RPS.Paper:
                            Score2 += 2;
                            Score2 += 6;
                            break;
                        case RPS.Scissors:
                            Score2 += 3;
                            Score1 += 6;
                            break;
                    }
                    break;
                case RPS.Paper:
                    Score1 += 2;
                    switch (Player2)
                    {
                        case RPS.Rock:
                            Score2 += 1;
                            Score1 += 6;
                            break;
                        case RPS.Paper:
                            Score2 += 2;
                            Score1 += 3;
                            Score2 += 3;

                            break;
                        case RPS.Scissors:
                            Score2 += 3;
                            Score2 += 6;
                            break;
                    }
                    break;
                case RPS.Scissors:
                    Score1 += 3;
                    switch (Player2)
                    {
                        case RPS.Rock:
                            Score2 += 1;
                            Score2 += 6;
                            break;
                        case RPS.Paper:
                            Score2 += 2;
                            Score1 += 6;
                            break;
                        case RPS.Scissors:
                            Score2 += 3;
                            Score1 += 3;
                            Score2 += 3;

                            break;
                    }
                    break;
            }
            return new Tuple<int, int>(Score1, Score2);
        }

        private static List<KeyValuePair<RPS, RPS>> GetInput()
        {
            string[] input = File.ReadAllLines(@"Inputs\RockPaperScissors.txt");

            List<KeyValuePair<RPS, RPS>> results = new List<KeyValuePair<RPS, RPS>>();

            foreach (var line in input)
            {
                var plays = line.Split(' ');
                //results.Add(new KeyValuePair<RPS, RPS>(InputConversion[plays[0]], GetResponse(InputConversion[plays[0]], ResponseConversion[plays[1]])));
                //part one
                results.Add(new KeyValuePair<RPS, RPS>(InputConversion[plays[0]], InputConversion[plays[1]]));
            }

            return results;
        }

        private static RPS GetResponse(RPS rPS, WDL wDL)
        {
            switch (rPS)
            {
                case RPS.Rock:
                    switch (wDL)
                    {
                        case WDL.Win:
                            return RPS.Paper;
                        case WDL.Draw:
                            return RPS.Rock;
                        case WDL.Lose:
                            return RPS.Scissors;
                    }
                    break;
                case RPS.Paper:
                    switch (wDL)
                    {
                        case WDL.Win:
                            return RPS.Scissors;
                        case WDL.Draw:
                            return RPS.Paper;
                        case WDL.Lose:
                            return RPS.Rock;
                    }
                    break;
                case RPS.Scissors:
                    switch (wDL)
                    {
                        case WDL.Win:
                            return RPS.Rock;
                        case WDL.Draw:
                            return RPS.Scissors;
                        case WDL.Lose:
                            return RPS.Paper;
                    }
                    break;
            }
            return RPS.Paper;
        }
    }
}
