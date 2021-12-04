using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions._4.Bingo;

namespace AdventOfCode2021.Solutions._4.Tests
{
    [TestClass()]
    public class Puzzle4Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var puzzle4 = new Puzzle4();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 4);
            var result = puzzle4.SolvePart1(input);
            Assert.AreEqual(4512, result);
        }

        [TestMethod()]
        public void CreateBingoCardTest()
        {
            var puzzle4 = new Puzzle4();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 4);
            var bingoGame = new BingoGame(input.ToList());
            Assert.AreEqual(3, bingoGame.BingoCards.Count);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var puzzle4 = new Puzzle4();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 4);
            var result = puzzle4.SolvePart2(input);
            Assert.AreEqual(1924, result);
        }
    }
}