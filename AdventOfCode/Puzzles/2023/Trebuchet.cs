using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    static class Trebuchet
    {

        public static string[] Input { get; set; }
        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\Trebuchet.txt");
            //Part1();
            Part2();
        }

        private static void Part1()
        {
            int sumCalibrationValues = 0;
            foreach (var line in Input)
            {
                if (line.Any())
                {
                    //Get first number to x 10 add to sum
                    sumCalibrationValues += GetFirstDigit(line) * 10;
                    //Reverse the line and get last number add to sum
                    sumCalibrationValues += GetFirstDigit(new string(line.Reverse().ToArray()));
                }
            }
            Console.WriteLine("Total Sum Calibration Values:");
            Console.WriteLine(sumCalibrationValues);
        }


        private static void Part2()
        {
            int sumCalibrationValues = 0;
            foreach (var line in Input)
            {
                if (line.Any())
                {
                    //Get first number to x 10 add to sum

                    var test = GetFirstDigitOrWord(line);
                    sumCalibrationValues += test * 10;
                    //Reverse the line and get last number add to sum
                    var test2 = GetFirstDigitOrWord(new string(line.Reverse().ToArray()), true);
                    sumCalibrationValues += test2;
                }
            }
            Console.WriteLine("Total Sum Calibration Values:");
            Console.WriteLine(sumCalibrationValues);
        }

        private static int GetFirstDigit(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (Char.IsDigit(str[i]))
                    return Convert.ToInt32(Char.GetNumericValue(str[i]));
            return 0;
        }

        private static int GetFirstDigitOrWord(string str, bool inverted = false)
        {
            string CurrentWord = "";

            for (int i = 0; i < str.Length; i++)
                if (Char.IsDigit(str[i]))
                    return Convert.ToInt32(Char.GetNumericValue(str[i]));
                else
                {
                    if (inverted)
                        CurrentWord = CurrentWord.Insert(0, str[i].ToString());
                    else
                        CurrentWord += str[i];

                    //Does Current Word Contain a written number
                    foreach (var writtenNumber in _writtenNumbers)
                        if (CurrentWord.Contains(writtenNumber))
                            return Array.IndexOf(_writtenNumbers, writtenNumber) + 1;
                }
            return 0;
        }

        static readonly string[] _writtenNumbers = new string[]
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
    }
}
