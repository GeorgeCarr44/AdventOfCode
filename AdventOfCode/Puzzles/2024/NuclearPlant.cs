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
                Trend trend = GetTrend(report);

                foreach (var v in report)
                {
                    if (prev.HasValue)
                    {
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
            int safeReportsCount = 0;
            foreach (var report in Reports)
            {
                if (!CheckReport(report))
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        List<int> trimmedReport = new List<int>(report);
                        trimmedReport.RemoveAt(i);
                        if (CheckReport(trimmedReport))
                        {
                            safeReportsCount++;
                            break;
                        }
                    }
                }
                else
                    safeReportsCount++;
            }
            Console.WriteLine("Total Safe Reports With Dampener: " + safeReportsCount);
        }


        private static bool CheckReport(List<int> report)
        {
            Trend trend = GetTrend(report);
            int? prev = null;

            for (int i = 0; i < report.Count; i++)
            {
                if (prev.HasValue)
                {
                    if (!SafetyCheck(report[i], report[prev.Value], trend))
                    {
                        return false;
                    }
                }
                prev = i;
            }
            return true;
        }

        private static Trend GetTrend(List<int> report)
        {
            int trendNum = 0;

            for (int i = 0; i < report.Count() - 1; i++)
            {
                if (report[i] < report[i + 1])
                    trendNum++;
                else
                    trendNum--;
            }

            if (trendNum > 0)
                return Trend.Increase;
            else
                return Trend.Decrease;
        }

        private static bool SafetyCheck(int v, int prev, Trend trend)
        {
            if ((trend == Trend.Increase && prev > v) || (trend == Trend.Decrease && prev < v))
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
