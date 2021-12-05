using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._5.Tests
{
    [TestClass()]
    public class Puzzle5Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            Puzzle5 puzzle5 = new Puzzle5();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 5);
            var result = puzzle5.SolvePart1(input);
            Assert.AreEqual(5, result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            Puzzle5 puzzle5 = new Puzzle5();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 5);
            var result = puzzle5.SolvePart2(input);
            Assert.AreEqual(12, result);
        }
    }
}