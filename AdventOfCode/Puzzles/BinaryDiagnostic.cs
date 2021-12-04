using System.Text;

namespace Advent_of_Code.BinaryDiagnostic
{
    static class BinaryDiagnostic
    {
        public static void TaskOne(string[] input)
        {
            var Gamma = GetGamma(input); //most common bit
            var Epsilon = InvertBinary(Gamma); ; //most common bit

            Console.WriteLine(BitStringToInt(Gamma) * BitStringToInt(Epsilon));
        }

        public static void TaskTwo(string[] input)
        {

            //Find and replace match values needs to change when methodised
            var GammaCharArray = GetGamma(input).Replace('X','1').ToCharArray();
            var firstLine = input[0];

            var filteredBinary = input;

            var oxygen = BitStringToInt(SearchForRating(input, Rating.Oxygen));
            var CO2 = BitStringToInt(SearchForRating(input, Rating.CO2));

            Console.WriteLine("Oxygen: " + oxygen);
            Console.WriteLine("CO2: " + CO2);
            Console.WriteLine("Life Support: " + oxygen * CO2);
        }

        enum Rating
        {
            Oxygen,
            CO2
        }

        private static string SearchForRating(string[] input, Rating rating)
        {
            //Find and replace match values needs to change when methodised


            var firstLine = input[0];

            var filteredBinary = input;

            for (int i = 0; i < firstLine.Length; i++)
            {
                filteredBinary = filteredBinary.Where(c => c[i] == GetRecurringBit(filteredBinary, i, rating)).ToArray();
                if (filteredBinary.Length == 1)
                {
                    return filteredBinary[0];
                }
            }

            if (filteredBinary.Length > 1)
            {
                Console.WriteLine("Error");
                foreach (var item in filteredBinary)
                {
                    Console.WriteLine(item);
                }

            }

            return "ERROR";
        }



        public static string GetGamma(string[] input)
        {
            var Gamma = ""; 
            var firstLine = input[0];

            for (int i = 0; i < firstLine.Length; i++)
            {
                Gamma += GetRecurringBit(input, i, Rating.Oxygen);

                var countZero = input.Count(c => c[i] == '0');
                var countOnes = input.Count(c => c[i] == '1');

                if (countZero > countOnes)
                    Gamma += "0";
                else if (countZero < countOnes)
                    Gamma += "1";
                else
                    Gamma += "X";
            }

            return Gamma;
        }

        private static char GetRecurringBit(string[] input, int position, Rating rating)
        {

            var countZero = input.Count(c => c[position] == '0');
            var countOnes = input.Count(c => c[position] == '1');

            if (rating == Rating.Oxygen)
            { 
                if (countZero > countOnes)
                    return '0';
                else if (countZero < countOnes)
                    return '1';
                else
                    return '1';
            }
            else if (rating == Rating.CO2)
            {
                if (countZero > countOnes)
                    return '1';
                else if (countZero < countOnes)
                    return '0';
                else
                    return '0';
            }


            return 'x';
        }




        public static int BitStringToInt(string bits)
        {
            var reversedBits = bits.Reverse().ToArray();
            var num = 0;
            for (var power = 0; power < reversedBits.Count(); power++)
            {
                var currentBit = reversedBits[power];
                if (currentBit == '1')
                {
                    var currentNum = (int)Math.Pow(2, power);
                    num += currentNum;
                }
            }

            return num;
        }

        public static string InvertBinary(string binary)
        {
            string inverted = "";
            var bArray = binary.ToCharArray();

            foreach (var b in bArray)
            {
                if (b == '0')
                    inverted += "1";
                else if (b == '1')
                    inverted += "0";
            }
            return inverted;
        }

        public static void Run(int task)
        {
            var input = File.ReadAllLines(@"C:\Users\gwcgr\Documents\Code\AdventOfCode\AdventOfCode\Inputs\BinaryDiagnostic.txt");

            if (task == 1)
            {
                TaskOne(input);
            }
            if (task == 2)
            {
                TaskTwo(input);
            }
        }
    }
}