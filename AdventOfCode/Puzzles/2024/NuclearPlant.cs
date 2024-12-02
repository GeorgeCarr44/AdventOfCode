using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2024
{
    static class NuclearPlant
    {
        private static List<List<int>> Reports { get; set; }

        public static void Run()
        {
            ReadInput(@"Inputs\2024\NuclearPlant.txt");
            Part1();
            Part2();
        }

        private static void Part1()
        {
            int safeReportsCount = Reports.Count;
            foreach (var report in Reports)
            {
                int? prev = null;
                Trend trend = Trend.None;

                foreach (var v in report)
                {
                    if (prev.HasValue)
                    {
                        // set increase decrease
                        if (trend == Trend.None)
                        {
                            trend = GetTrend(v, prev.Value);
                            
                        }

                        if (!SafetyCheck(v, prev.Value, trend))
                        {
                            --safeReportsCount;
                            break;
                        }
                    }
                    prev = v;
                }

            }
            Console.WriteLine("Total Safe Reports: " + safeReportsCount);
        }

        private static void Part2()
        {
            int safeReportsCount = Reports.Count;
            foreach (var report in Reports)
            {
                int? prev = null;
                Trend trend = Trend.None;
                int problems = 0;

                foreach (var v in report)
                {
                    if (prev.HasValue)
                    {
                        // set increase decrease
                        if (trend == Trend.None)
                        {
                            trend = GetTrend(v, prev.Value);
                            
                        }

                        if (!SafetyCheck(v, prev.Value, trend))
                        {
                            problems++;
                            if (problems > 1)
                            {
                                --safeReportsCount;
                                break;
                            }
                        }
                    }
                    prev = v;
                }

            }
            Console.WriteLine("Total Safe Reports With Dampener: " + safeReportsCount);
        }

        private static Trend GetTrend(int v, int prev)
        {
            if (v > prev)
                return Trend.Increase;
            else
                return Trend.Decrease;
        }

        private static bool SafetyCheck(int v, int prev, Trend trend)
        {
            if (trend != GetTrend(v, prev))
                return false;

            var diff = GetDifference(v, prev);
            return diff >= 1 && diff <= 3;
        }

        private static int GetDifference(int v, int prev)
        {
            return Math.Abs(v - prev);
        }

        private static void ReadInput(string input)
        {
            var Input = File.ReadAllLines(input);
            Reports = new List<List<int>>();
            foreach (var l in Input)
            {
                var report = new List<int>();
                var r = l.Split(' ');
                foreach (var v in r)
                {
                    report.Add(int.Parse(v));
                }
                Reports.Add(report);
            }
        }

        enum Trend
        {
            None,
            Increase,
            Decrease
        }
    }
}
