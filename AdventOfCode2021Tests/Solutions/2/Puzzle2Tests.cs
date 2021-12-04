using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions.Tests
{
    [TestClass()]
    public class Puzzle2Tests
    {
        [TestMethod()]
        public void SolveTestwDemo()
        {
            var puzzle2 = new Puzzle2();
            var result = puzzle2.SolvePart1(FileManager.Load("D:\\Programming\\adventofcode\\adventofcode2021\\AdventOfCode2021\\Solutions\\2\\Data\\DemoInput.txt"));
            Assert.AreEqual(150, result);
        }

        [TestMethod()]
        public void SolveTestwDemoPart2()
        {
            var puzzle2 = new Puzzle2();
            var result = puzzle2.SolvePart2(FileManager.Load("D:\\Programming\\adventofcode\\adventofcode2021\\AdventOfCode2021\\Solutions\\2\\Data\\DemoInput.txt"));
            Assert.AreEqual(900, result);
        }
    }
}