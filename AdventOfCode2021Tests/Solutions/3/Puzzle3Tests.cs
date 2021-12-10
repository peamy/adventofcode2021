using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;

namespace AdventOfCode2021.Solutions._3.Tests
{
    [TestClass()]
    public class Puzzle3Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {
            var puzzle3 = new Puzzle3();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 3);
            var result = puzzle3.SolvePart1(input);
            Assert.AreEqual("198", result);
        }

        [TestMethod()]
        public void GetGammaTest()
        {
            var puzzle3 = new Puzzle3();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 3);
            var array = puzzle3.Make2dArray(input);
            var gamma = puzzle3.GetGamma(array);
            Assert.AreEqual("10110", gamma);
        }

        [TestMethod()]
        public void BinaryToIntTest()
        {
            var puzzle3 = new Puzzle3();
            int bin2int = puzzle3.BinarystringToInt("10110");            
            Assert.AreEqual(22, bin2int);
            int bin2int2 = puzzle3.BinarystringToInt("010110");
            Assert.AreEqual(22, bin2int2);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var puzzle3 = new Puzzle3();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 3);
            var result = puzzle3.SolvePart2(input);
            Assert.AreEqual("230", result);
        }

        [TestMethod()]
        public void GetOxygenTest()
        {
            var puzzle3 = new Puzzle3();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 3);
            var oxygen = puzzle3.GetOxygen(input.ToList());
            Assert.AreEqual("10111", oxygen);
        }

        [TestMethod()]
        public void GetCO2Test()
        {
            var puzzle3 = new Puzzle3();
            var input = FileManager.LoadPuzzle("DemoInput.txt", 3);
            var oxygen = puzzle3.GetCO2(input.ToList());
            Assert.AreEqual("01010", oxygen);
        }
    }
}