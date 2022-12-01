using System.Text.RegularExpressions;

namespace Advent_of_Code.HydrothermalVenture
{
    static class HydrothermalVenture
    {
        public static int[,] ventMap;
        public static void Run()
        {
            string[] input = System.IO.File.ReadAllLines(@"Inputs\HydrothermalVenture.txt");

            List<Line> lines = new List<Line>();

            int arrayX = 0;
            int arrayY = 0;

            foreach (string inputRow in input)
            {
                string[] coordinates = inputRow.Split("->");

                Coordinate start = new Coordinate(coordinates[0]);
                Coordinate end = new Coordinate(coordinates[1]);

                arrayX = arrayX < start.X ? start.X : arrayX;
                arrayY = arrayY < start.Y ? start.Y : arrayY;

                lines.Add(new Line(start, end));
            }

            ventMap = new int[arrayX + 2, arrayY + 2];

            foreach(Line l in lines)
            {
                l.DrawLine();
            }

            int totalOverlapPoints = 0;

            //for (int y = 0; y < ventMap.GetLength(1); y++)
            //{
            //    for (int x = 0; x < ventMap.GetLength(0); x++)
            //    {
            //        Console.Write(ventMap[x, y]);
            //    }
            //    Console.WriteLine();
            //}

            foreach (int point in ventMap)
            {
                if(point > 1)
                    totalOverlapPoints++;
            }
            Console.WriteLine();
            Console.WriteLine(totalOverlapPoints);
        }
            
        class Line
        {
            public Coordinate StartPosition;
            public Coordinate EndPosition;

            public List<Coordinate> CoordinateArray;
            public Line(Coordinate start, Coordinate end)
            {
                this.StartPosition = start;
                this.EndPosition = end;

                //Instantiate and add start coord
                CoordinateArray = new List<Coordinate>
                {
                };

                if (start.X == end.X)
                {
                    var lowNumber = start.Y < end.Y ? start.Y : end.Y;
                    var highNumber = start.Y > end.Y ? start.Y : end.Y;
                    for (int Y = lowNumber; Y < highNumber + 1; Y++)
                        CoordinateArray.Add(new Coordinate(start.X, Y));
                }
                else if (start.Y == end.Y)
                {
                    var lowNumber = start.X < end.X ? start.X : end.X;
                    var highNumber = start.X > end.X ? start.X : end.X;
                    for (int X = lowNumber; X < highNumber + 1; X++)
                        CoordinateArray.Add(new Coordinate(X, start.Y));
                }
                else
                {
                    

                    var gradient = (start.Y - end.Y)/(start.X - end.X);
                    var c = start.Y - gradient * start.X;
                    
                    //throw new NotImplementedException("Line is diagonal");
                    CoordinateArray = new List<Coordinate>();
                    var lowNumber = start.X < end.X ? start.X : end.X;
                    var highNumber = start.X > end.X ? start.X : end.X;
                    for (int X = lowNumber; X < highNumber + 1; X++)
                    {
                        int Y = gradient * X + c;
                        CoordinateArray.Add(new Coordinate(X, Y));

                    }
                }
            }

            public void DrawLine()
            {
                foreach (Coordinate coord in CoordinateArray)
                {
                    int value = ventMap[coord.X, coord.Y];
                    ventMap.SetValue(++value, coord.X, coord.Y);
                }
            }
        }

        class Coordinate
        {
            public int X;
            public int Y;

            public Coordinate(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public Coordinate(string coordinate)
            {
                var splitCoordinate = coordinate.Trim().Split(',');
                this.X = Int32.Parse(splitCoordinate[0]);
                this.Y = Int32.Parse(splitCoordinate[1]);
            }
        }
    }
}
