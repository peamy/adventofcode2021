using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._23.Tests
{
    [TestClass()]
    public class Puzzle23Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 23);
            var puzzle = new Puzzle23();
            var result = puzzle.SolvePart1(input);
            Assert.AreEqual("-1", result);
        }
    }
}