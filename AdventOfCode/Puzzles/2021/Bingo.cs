using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    static class Bingo
    {
        public static void Run(int task)
        {
            List<string> input = File.ReadAllLines(@"Inputs\Bingo.txt").ToList();

            // create an int list of the random numbers
            List<int> randomNumbers = new List<int>();
            foreach (string num in input.First().Split(',')) 
            {
                randomNumbers.Add(Int32.Parse(num));
            }

            //Remove the random numbers from index
            input.RemoveAt(0);

            List<BingoSheet> bingoSheets = new List<BingoSheet>();

            List<string> tmpBingoLines = new List<string>();

            //Create the sheets data
            foreach (string line in input)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    //finished bingo sheet
                    if (tmpBingoLines.Count != 0)
                    {

                        bingoSheets.Add(new (tmpBingoLines));
                        tmpBingoLines = new List<string>();
                    }
                }
                else
                {
                    tmpBingoLines.Add(line);
                }
            }
            //Add final sheet
            bingoSheets.Add(new BingoSheet(tmpBingoLines));
            tmpBingoLines = new List<string>();

            GetWinningSheet(randomNumbers, bingoSheets, task);
        }

        private static void GetWinningSheet(List<int> randomNumbers, List<BingoSheet> bingoSheets, int task)
        {
            foreach (int randomNumber in randomNumbers)
            {
                foreach (BingoSheet bingoSheet in bingoSheets)
                {
                    bingoSheet.MarkNumber(randomNumber);
                    if (bingoSheet.HasRow() || bingoSheet.HasColumn())
                    {
                        if(task == 1 || bingoSheets.Count == 1)
                        {
                            Console.WriteLine("Score: " + bingoSheet.GetScore(randomNumber));
                            return;
                        }

                        var tmp = bingoSheets;
                        tmp.Remove(bingoSheet);
                        if (task == 2)
                        {
                            GetWinningSheet(randomNumbers, tmp, task);
                            return;
                        }

                        //return;
                    }

                }
            }
        }

        /// <summary>
        /// A 2 dimensional array of bingo numbers
        /// </summary>
        class BingoSheet 
        {
            public BingoNumber[,] BingoNumbers { get; set; }

            public BingoSheet(BingoNumber[,] bingoNumbers)
            {
                BingoNumbers = bingoNumbers; 
            }

            public BingoSheet(List<string> bingoLine)
            {
                BingoNumber[,] tmpBingoNumbers = new BingoNumber[Regex.Split(bingoLine[0].Trim(), @"\s+").ToList().Count, bingoLine.Count];

                //each line
                for (int y = 0; y < bingoLine.Count; y++)
                {
                    string[] currentLineArray = Regex.Split(bingoLine[y].Trim(), @"\s+");
                    //each digit
                    for (int x = 0; x < currentLineArray.Length; x++)
                    {
                        var number = Int32.Parse(currentLineArray[x]);
                        tmpBingoNumbers.SetValue(new BingoNumber(number, false), x, y);
                    }
                }

                BingoNumbers = tmpBingoNumbers;
            }

            public void PrintSheet()
            {
                Console.Write(BingoNumbers.ToString());
            }

            public void MarkNumber(int num)
            {
                foreach (BingoNumber bingoNumber in BingoNumbers)
                {
                    if(bingoNumber.Value == num)
                    {
                        bingoNumber.Marked = true;
                        return;
                    }
                }
            }

            public bool HasColumn()
            {
                bool isRowMarked = false;

                for (int x = 0; x < BingoNumbers.GetLength(0); x++)
                {
                    //Set to true for start of row.
                    isRowMarked = true;

                    for (int y = 0; y < BingoNumbers.GetLength(1); y++)
                    {
                        if(!BingoNumbers[x, y].Marked)
                        {
                            isRowMarked = false;
                            break;
                        }
                    }

                    //Found a marked row no need to continue
                    if (isRowMarked)
                    {
                        return true;
                    }
                }

                return isRowMarked;
            }

            public bool HasRow()
            {
                bool isColumnMarked = false;

                for (int y = 0; y < BingoNumbers.GetLength(1); y++)
                {
                    //Set to true for start of column.
                    isColumnMarked = true;

                    for (int x = 0; x < BingoNumbers.GetLength(0); x++)
                    {
                        if (!BingoNumbers[x, y].Marked)
                        {
                            isColumnMarked = false;
                            break;
                        }
                    }

                    //Found a marked column no need to continue
                    if (isColumnMarked)
                    {
                        return true;
                    }
                }

                return isColumnMarked;
            }

            public int GetScore(int randomNumber)
            {
                int score = 0;
                foreach (BingoNumber bingoNumber in BingoNumbers)
                {
                    if (!bingoNumber.Marked)
                    {
                        score += bingoNumber.Value;
                    }
                }
                return score * randomNumber;
            }

        }

        /// <summary>
        /// A single number that can be marked
        /// </summary>
        class BingoNumber
        {
            public int Value { get; set; }
            public bool Marked { get; set; }

            public BingoNumber(int value, bool marked)
            {
                Value = value;
                Marked = marked;
            }
        }
    }
}
