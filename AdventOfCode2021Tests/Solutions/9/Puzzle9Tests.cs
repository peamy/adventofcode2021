using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._9.Tests
{
    [TestClass()]
    public class Puzzle9Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 9);
            var puzzle = new Puzzle9();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("15", result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 9);
            var puzzle = new Puzzle9();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("1134", result);
        }
    }
}