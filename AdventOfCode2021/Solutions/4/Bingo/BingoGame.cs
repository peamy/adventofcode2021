using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._4.Bingo
{
    public class BingoGame
    {
        public List<BingoCard>BingoCards;
        public string[] BingoNumbers;

        public BingoGame(List<String> puzzleInput)
        {
            BingoCards = new List<BingoCard>();
            BingoNumbers = puzzleInput[0].Split(',');

            // take out the numbers. then 5 rows + an enter for each card
            int bingoCards = (puzzleInput.Count - 1) / 6;

            for (int i = 0; i < bingoCards; i++)
            {
                BingoCards.Add(
                    new BingoCard(
                        new List<string> 
                        { 
                            puzzleInput[i * 6 +2],
                            puzzleInput[i * 6 +3],
                            puzzleInput[i * 6 +4],
                            puzzleInput[i * 6 +5],
                            puzzleInput[i * 6 +6],
                        })
                    );
            }
        }

        public BingoCard PlayBingo()
        {
            foreach(string numberstring in BingoNumbers)
            {
                int number = int.Parse(numberstring);
                foreach(BingoCard bingocard in BingoCards)
                {
                    if (bingocard.MarkNumber(number))
                    {
                        return bingocard;
                    }
                }
            }
            return null;
        }

        public BingoCard PlayBingoTillLastOneWins()
        {
            foreach (string numberstring in BingoNumbers)
            {
                int number = int.Parse(numberstring);
                List<BingoCard> losers = new List<BingoCard>();
                foreach (BingoCard bingocard in BingoCards)
                {
                    if (!bingocard.MarkNumber(number))
                    {
                        losers.Add(bingocard);
                    }
                }
                if (BingoCards.Count == 1)
                    return BingoCards[0];
                BingoCards = losers;
            }
            return null;
        }

    }
}
