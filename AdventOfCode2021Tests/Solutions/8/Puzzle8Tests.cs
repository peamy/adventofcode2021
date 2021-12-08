using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions._8.Objects;

namespace AdventOfCode2021.Solutions._8.Tests
{
    [TestClass()]
    public class Puzzle8Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 8);
            var puzzle = new Puzzle8();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("26", result);
        }

        [TestMethod()]
        public void CreateDisplayTest()
        { 
            Display dp = new Display("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe");
            Assert.AreEqual(4, dp.displaying.Length);
            Assert.AreEqual(10, dp.numbers.Length);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 8);
            var puzzle = new Puzzle8();
            var result = puzzle.SolvePart2(input);
            Assert.AreEqual("61229", result);
        }
    }
}