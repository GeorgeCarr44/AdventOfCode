namespace Advent_of_Code.CrabSubmarines
{
    static class CrabSubmarines
    {
        public static void Run()
        {
            List<int> input = System.IO.File.ReadAllLines(@"C:\Users\gwcgr\Documents\Code\AdventOfCode\AdventOfCode\Inputs\CrabSubmarines.txt")[0].Split(',').Select(int.Parse).ToList();


            int max = input.Max();
            int min = input.Min();

            int[] positions = new int[max - min + 1];

            foreach (int i in input)
                positions[i]++;

            decimal minFuel = 0;

            // d = desired position
            for (int d = min; d < max + 1; d++)
            {
                Console.WriteLine($"desired position: {d}");
                decimal loopFuel = 0;

                // i = current column being calculated
                for (int i = min; i < max + 1; i++)
                {
                    decimal x = Math.Abs(d - i);
                    decimal n = ((x * x) / 2 + x / 2);

                    loopFuel += (decimal)positions[i] * n;
                }

                if (minFuel > loopFuel || minFuel == 0)
                    minFuel = loopFuel;
            }

            Console.WriteLine(minFuel);
        }
    }
}