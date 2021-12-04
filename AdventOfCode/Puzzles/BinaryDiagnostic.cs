using System.Text;

namespace Advent_of_Code.BinaryDiagnostic
{
    static class BinaryDiagnostic
    {
        public static void TaskOne()
        {

            var input = File.ReadAllLines(@"C:\Users\gwcgr\Documents\Code\AdventOfCode\AdventOfCode\Inputs\BinaryDiagnostic.txt");
            
            var Gamma = ""; //most common bit
            var Epsilon = ""; //most common bit

            var firstLine = input[0];

            for (int i = 0; i < firstLine.Length; i++)
            {
                var countZero = input.Count(c => c[i] == '0');
                var countOnes = input.Count(c => c[i] == '1');

                if (countZero > countOnes)
                    Gamma += "0";
                else if(countZero < countOnes)
                    Gamma += "1";
            }

            Epsilon = InvertBinary(Gamma);

            Console.WriteLine(BitStringToInt(Gamma) * BitStringToInt(Epsilon));
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
            if (task == 1)
            {
                TaskOne();
            }
        }
    }
}