using AdventOfCode2021.Solutions._16.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._16
{
    public class Puzzle16 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            var packets = new PacketDecoder().DecodeFromHex(input[0]);
            int total = 0;
            foreach(var packet in packets)
            {
                total += packet.Version;
            }
            return total.ToString();
        }

        public string SolvePart2(string[] input)
        {
            var packets = new PacketDecoder().DecodeFromHex(input[0], true);
            long total = 0;
            foreach (var packet in packets)
            {
                total += packet.GetValue();
            }
            // actual input = too low
            return total.ToString();
        }

        
    }
}
