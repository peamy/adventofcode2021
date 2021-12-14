using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._14.Tests
{
    [TestClass()]
    public class Puzzle14Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 14);
            var puzzle = new Puzzle14();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("1588", result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 14);
            var puzzle = new Puzzle14();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("2188189693529", result);
        }
    }
}