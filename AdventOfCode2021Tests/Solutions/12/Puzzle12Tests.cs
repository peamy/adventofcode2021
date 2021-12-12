using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._12.Tests
{
    [TestClass()]
    public class Puzzle12Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 12);
            var puzzle = new Puzzle12();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("226", result);
        }

        [TestMethod()]
        public void SolvePart1Test2()
        {
            var input = FileManager.LoadPuzzle("DemoInput2.txt", 12);
            var puzzle = new Puzzle12();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("19", result);
        }

        [TestMethod()]
        public void SolvePart21Test2()
        {
            var input = FileManager.LoadPuzzle("DemoInput2.txt", 12);
            var puzzle = new Puzzle12();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("103", result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 12);
            var puzzle = new Puzzle12();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("3509", result);
        }
    }
}