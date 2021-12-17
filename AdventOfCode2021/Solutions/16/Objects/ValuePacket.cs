using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._16.Objects
{
    public class ValuePacket : Packet
    {
        public ValuePacket(string input)
        {
            Version = (int)PacketDecoder.BinarystringToLong(input.Substring(0, 3));
            Id = (int)PacketDecoder.BinarystringToLong(input.Substring(3, 3));
            packetStr = input;
            value = GetValue(-1);
        }

        public override long GetValue(int depth = 0)
        {
            string total = "";
            for(int i = 6; i < packetStr.Length - 4; i += 5)
            {                
                total += packetStr.Substring(i+1, 4);
                if (packetStr.Substring(i, 1) == "0")
                    break;
            }

            string depthstr = "";
            for (int i = 0; i < depth; i++)
            {
                depthstr += "---";
            }
            Console.WriteLine(depthstr + $"{Version} {Id} {PacketDecoder.BinarystringToLong(total)}");
            return PacketDecoder.BinarystringToLong(total);
        }
    }
}
