using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._6.Tests
{
    [TestClass()]
    public class Puzzle6Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 6);
            var puzzle6 = new Puzzle6();
            var result = puzzle6.SolvePart1(input);
            Assert.AreEqual("5934", result);
        }

        [TestMethod()]
        public void GetChildrenTest()
        {
            //var input = FileManager.LoadPuzzle("DemoInput.txt", 6);
            var puzzle6 = new Puzzle6();            
            //Assert.AreEqual(2, puzzle6.CountSelfAndChildren(0, 1));
            //Assert.AreEqual(1, puzzle6.CountSelfAndChildren(0, 0));
            //Assert.AreEqual(3, puzzle6.CountSelfAndChildren(0, 8));
            //Assert.AreEqual(4, puzzle6.CountSelfAndChildren(0, 10));
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var input = FileManager.LoadPuzzle("DemoInput.txt", 6);
            var puzzle6 = new Puzzle6();
            var result = puzzle6.SolvePart2(input);
            Assert.AreEqual("26984457539", result);
        }
    }
}