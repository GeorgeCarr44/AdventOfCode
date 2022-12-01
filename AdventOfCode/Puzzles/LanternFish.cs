namespace Advent_of_Code.LanternFish
{
    static class LanternFish
    {
        public static void Run(int days)
        {
            List<int> input = System.IO.File.ReadAllLines(@"Inputs\LanternFish.txt")[0].Split(',').Select(int.Parse).ToList();

            long zero = 0;
            long one = 0;
            long two = 0;
            long three = 0;
            long four = 0;
            long five = 0;
            long six = 0;
            long seven = 0;
            long eight = 0;

            foreach (int i in input)
            {
                switch (i)
                {
                    case 0:
                        zero++;
                        break;
                    case 1:
                        one++;
                        break;
                    case 2:
                        two++;
                        break;
                    case 3:
                        three++;
                        break;
                    case 4:
                        four++;
                        break;
                    case 5:
                        five++;
                        break;
                    case 6:
                        seven++;
                        break;
                }
            }

            for (int i = 0; i < days; i++)
            {
                var newfish = zero;

                zero = one;
                one = two;
                two = three;
                three = four;
                four = five;
                five = six;
                six = seven + newfish;
                seven = eight;
                eight = newfish;
            }

            long totalFish = zero + one + two + three + four + five + six + seven + eight;
            Console.WriteLine(totalFish);
        }
    }
}