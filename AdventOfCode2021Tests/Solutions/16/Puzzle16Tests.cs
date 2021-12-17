using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Solutions._16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions._16.Objects;

namespace AdventOfCode2021.Solutions._16.Tests
{
    [TestClass()]
    public class Puzzle16Tests
    {
        [TestMethod()]
        public void SolvePart1Test()
        {            
            var puzzle = new Puzzle16();
            var result = puzzle.SolvePart1(new string[] { "D2FE28" });
            Assert.AreEqual("6", result);
            result = puzzle.SolvePart1(new string[] { "8A004A801A8002F478" });
            Assert.AreEqual("16", result);
            result = puzzle.SolvePart1(new string[] { "620080001611562C8802118E34" });
            Assert.AreEqual("12", result);
            result = puzzle.SolvePart1(new string[] { "C0015000016115A2E0802F182340" });
            Assert.AreEqual("23", result);
            result = puzzle.SolvePart1(new string[] { "A0016C880162017C3686B18A3D4780" });
            Assert.AreEqual("31", result);
        }

        [TestMethod()]
        public void SolvePart2Test()
        {
            var puzzle = new Puzzle16();
            var result = puzzle.SolvePart2(new string[] { "C200B40A82" });
            Assert.AreEqual("3", result);
            result = puzzle.SolvePart2(new string[] { "04005AC33890" });
            Assert.AreEqual("54", result);
            result = puzzle.SolvePart2(new string[] { "880086C3E88112" });
            Assert.AreEqual("7", result);
            result = puzzle.SolvePart2(new string[] { "CE00C43D881120" });
            Assert.AreEqual("9", result);
            result = puzzle.SolvePart2(new string[] { "D8005AC2A8F0" });
            Assert.AreEqual("1", result);
            result = puzzle.SolvePart2(new string[] { "F600BC2D8F" });
            Assert.AreEqual("0", result);
            result = puzzle.SolvePart2(new string[] { "9C005AC2F8F0" });
            Assert.AreEqual("0", result);
            result = puzzle.SolvePart2(new string[] { "9C0141080250320F1802104A08" });
            Assert.AreEqual("1", result);

        }

        [TestMethod()]
        public void ValueDecodeTest()
        {
            ValuePacket packet = new ValuePacket("110100101111111000101000");
            Assert.AreEqual(2021, packet.GetValue());
            packet = new ValuePacket("01010000001");
            Assert.AreEqual(1, packet.GetValue());
            packet = new ValuePacket("10010000010");
            Assert.AreEqual(2, packet.GetValue());
            packet = new ValuePacket("0011000001100000");
            Assert.AreEqual(3, packet.GetValue());

            packet = new ValuePacket("001100000110000");
            Assert.AreEqual(3, packet.GetValue());
            packet = new ValuePacket("00110000011000");
            Assert.AreEqual(3, packet.GetValue());
            packet = new ValuePacket("0011000001100");
            Assert.AreEqual(3, packet.GetValue());
            packet = new ValuePacket("001100000110");
            Assert.AreEqual(3, packet.GetValue());
            packet = new ValuePacket("001100000110000001001010101001010");
            Assert.AreEqual(3, packet.GetValue());

        }

        [TestMethod()]
        public void DecodeBinaryDecodeTest()
        {
            long result = PacketDecoder.BinarystringToLong("00100101010000001011111001000000000");
            Assert.AreEqual(5000000000, result);
        }

        [TestMethod()]
        public void DecodeBinaryDecodeTest2()
        {
            ValuePacket packet = new ValuePacket("001100100011001011010100001010111111100101000000000");
            Assert.AreEqual(5000000000, packet.GetValue());

        }
    }
}