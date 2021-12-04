using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._4.Bingo
{
    public class BingoCard
    {
        public BingoNumber[,] bingoNumbers;
        private int lastNumber = 0;
        
        public BingoCard(List<String> numbers)
        {
            bingoNumbers = new BingoNumber[5, 5];
            // count should always be 5
            for (int i = 0; i < numbers.Count; i++)
            {                
                var splitNumbers = numbers[i].Split(' ');
                // count should always be 5, but double spaces messes up the split function.
                int j = 0;
                foreach(string stringNumber in splitNumbers)
                {
                    if (stringNumber != "")
                    {
                        bingoNumbers[i, j] = new BingoNumber()
                        {
                            Number = int.Parse(stringNumber)
                        };
                        j++;
                    }
                }
            }
        }

        public bool MarkNumber(int number)
        {
            lastNumber = number;
            foreach(BingoNumber bingonumber in bingoNumbers)
            {
                if(bingonumber.Number == number)
                {
                    bingonumber.Marked = true;
                    break;
                }
            }
            return HasBingo();
        }

        public bool HasBingo()
        {
            for(int i=0; i < 5; i++)
            {
                if (bingoNumbers[i, 0].Marked &&
                    bingoNumbers[i, 1].Marked &&
                    bingoNumbers[i, 2].Marked &&
                    bingoNumbers[i, 3].Marked &&
                    bingoNumbers[i, 4].Marked)
                    return true;
            }

            for (int i = 0; i < 5; i++)
            {
                if (bingoNumbers[0, i].Marked &&
                    bingoNumbers[1, i].Marked &&
                    bingoNumbers[2, i].Marked &&
                    bingoNumbers[3, i].Marked &&
                    bingoNumbers[4, i].Marked)
                    return true;
            }
            return false;
        }

        public int GetScore()
        {
            int sum = 0;
            foreach(BingoNumber bn in bingoNumbers)
            {
                if (!bn.Marked)
                    sum += bn.Number;
            }
            return sum * lastNumber;
        }
    }
}
