using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._11.Tests
{
    [TestClass()]
    public class Puzzle11Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 11);
            var puzzle = new Puzzle11();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("1656", result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 11);
            var puzzle = new Puzzle11();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("195", result);
        }
    }
}