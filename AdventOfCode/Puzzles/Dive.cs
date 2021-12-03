namespace Advent_of_Code.Dive
{
    static class Dive
    {
        enum Direction
        {
            up,
            down,
            forward,
            backward
        }

        class Command
        {
            public Direction Direction;
            public int Distance;

            public Command(string input)
            {
                string[] splitInput = input.Split(' ');
                Direction = (Direction)Enum.Parse(typeof(Direction), splitInput[0]);
                Distance = int.Parse(splitInput[1]);
            }
        }

        public static void Run(int task)
        {

            string[] input = System.IO.File.ReadAllLines(@"C:\Users\gwcgr\Documents\Code\AdventOfCode\AdventOfCode\Inputs\Dive.txt");

            int depth = 0;
            int horizontalPosition = 0;
            int aim = 0;

            for (int i = 0; i < input.Length; i++)
            {
                Command command = new Command(input[i]);

                switch (command.Direction)
                {
                    case Direction.up:
                        if (task == 1)
                            depth -= command.Distance;
                        else if (task == 2)
                            aim -= command.Distance;
                        break;
                    
                    case Direction.down:
                        if (task == 1)
                            depth += command.Distance;
                        else if (task == 2)
                            aim += command.Distance;
                        break;

                    case Direction.forward:
                        if (task == 1)
                            horizontalPosition += command.Distance;
                        else if (task == 2)
                            horizontalPosition += command.Distance;
                            depth += aim * command.Distance;
                        break;

                    case Direction.backward:
                        break;
                }
            }
            Console.WriteLine(depth * horizontalPosition);
        }
    }
}