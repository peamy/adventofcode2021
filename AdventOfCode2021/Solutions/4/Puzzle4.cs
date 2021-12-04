using AdventOfCode2021.Solutions._4.Bingo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._4
{
    public class Puzzle4 : Puzzle
    {
        public int SolvePart1(string[] input)
        {
            BingoGame game = new BingoGame(input.ToList());
            var winner = game.PlayBingo();

            return winner.GetScore();
        }

        public int SolvePart2(string[] input)
        {
            BingoGame game = new BingoGame(input.ToList());
            var lastwinner = game.PlayBingoTillLastOneWins();

            return lastwinner.GetScore();
        }
    }
}
