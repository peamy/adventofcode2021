using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._10.Tests
{
    [TestClass()]
    public class Puzzle10Tests
    {
        [TestMethod()]
        public void FindFirsIllegalTest()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 10);
            var puzzle = new Puzzle10();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("26397", result);
        }

        [TestMethod()]
        public void AutoCompleteTest()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 10);
            var puzzle = new Puzzle10();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("288957", result);
        }

        [TestMethod()]
        public void AutoCompleteScoreTest()
        {
            var puzzle = new Puzzle10();
            var result = puzzle.FixSyntaxIllegal("[({(<(())[]>[[{[]{<()<>>");
            Assert.AreEqual(288957, result);
        }
    }
}