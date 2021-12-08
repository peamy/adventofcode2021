using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._7.Tests
{
    [TestClass()]
    public class Puzzle7Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 7);
            var puzzle7 = new Puzzle7();
            var result = puzzle7.SolvePart1(input);
            Assert.AreEqual("37", result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 7);
            var puzzle7 = new Puzzle7();
            var result = puzzle7.SolvePart2(input);
            Assert.AreEqual("168", result);
        }

        [TestMethod()]
        public void GetFuelKostpt2Test()
        {
            var puzzle7 = new Puzzle7();
            Assert.AreEqual(0, puzzle7.GetFuelKostPt2(0));
            Assert.AreEqual(1, puzzle7.GetFuelKostPt2(1));
            Assert.AreEqual(3, puzzle7.GetFuelKostPt2(2));
            Assert.AreEqual(6, puzzle7.GetFuelKostPt2(3));
            Assert.AreEqual(10, puzzle7.GetFuelKostPt2(4));
            Assert.AreEqual(15, puzzle7.GetFuelKostPt2(5));
        }
    }
}