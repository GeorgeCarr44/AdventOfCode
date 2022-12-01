
namespace AdventOfCode.Puzzles
{
    static class SonarSweep
    {

        public static void Run(int task)
        {
            // Advent of Code

            //Day 1: Sonar Sweep
            List<int> input = System.IO.File.ReadAllLines(@"Inputs/SonarSweep.txt").Select(int.Parse).ToList();
            var previousDepth = 0;
            var currentDepth = 0;
            var increaseCount = 0;
            if (task == 1)
            {
                // Compare independent values
                for (int i = 0; i < input.Count; i++)
                {
                    currentDepth = input[i];
                    var suffix = GetSuffix(currentDepth, previousDepth);
                    Console.WriteLine($"{currentDepth} {suffix}");
                    previousDepth = currentDepth;
                }

                Console.WriteLine($"Total times increased = {increaseCount}");
            }
            else if (task == 2)
            {
                // Compare 3 measurement windows

                var currentWindow = 0;
                var previousWindow = 0;

                for (int i = 0; i < input.Count - 2; i++)
                {
                    currentWindow = input[i] + input[i + 1] + input[i + 2];
                    var suffix = GetSuffix(currentWindow, previousWindow);
                    Console.WriteLine($"{currentWindow} {suffix}");
                    previousWindow = currentWindow;
                }

                Console.WriteLine($"Total times increased = {increaseCount}");
            }

            string GetSuffix(int currentDepth, int previousDepth)
            {
                if (previousDepth == 0)
                    return "(N/A - no previous measurement)";
                else if (previousDepth < currentDepth)
                {
                    increaseCount++;
                    return "(increased)";
                }
                else if (previousDepth > currentDepth)
                    return "(decreased)";
                else
                    return "(no change)";
            }
        }
    }
}

