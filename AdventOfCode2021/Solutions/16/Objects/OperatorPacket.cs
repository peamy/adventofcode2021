using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._16.Objects
{
    public class OperatorPacket : Packet
    {
        public List<Packet> SubPackets = new List<Packet>();
        public long amountOfSubpackets = 0;
        public bool UseLength = false;
        public OperatorPacket(string input)
        {
            Version = (int)PacketDecoder.BinarystringToLong(input.Substring(0, 3));
            Id = (int)PacketDecoder.BinarystringToLong(input.Substring(3, 3));
        }

        private int depth;
        public override long GetValue(int depth = 0)
        {
            this.depth = depth;
            switch (Id)
            {                
                case 0:
                    value = returnSum();
                    break;
                case 1:
                    value = returnProduct();
                    break;
                case 2:
                    value = returnMinimum();
                    break;
                case 3:
                    value = returnMaximum();
                    break;
                case 5:
                    value = greaterThan();
                    break;
                case 6:
                    value = lessThan();
                    break;
                case 7:
                    value = areEqual();
                    break;
            }

            string depthstr = "";
            for(long i = 0; i < depth; i++)
            {
                depthstr += "---";
            }
            Console.WriteLine(depthstr + $"{Version} {Id} {value}");
            return value;
        }

        private long returnSum()
        {
            long sum = 0;
            foreach(var packet in SubPackets)
            {
                sum += packet.GetValue(depth + 1);
            }
            return sum;
        }

        private long returnProduct()
        {
            if (SubPackets.Count == 1)
                return SubPackets[0].GetValue();
            long sum = 1;
            foreach (var packet in SubPackets)
            {
                var value = packet.GetValue(depth + 1);
                sum = sum * value;
            }
            return sum;
        }

        private long returnMinimum()
        {
            long min = long.MaxValue;
            foreach(var subpacket in SubPackets)
            {
                var subvalue = subpacket.GetValue(depth + 1);
                if (subvalue < min)
                    min = subvalue;
            }
            return min;
        }

        private long returnMaximum()
        {
            long max = 0;
            foreach (var subpacket in SubPackets)
            {
                var subvalue = subpacket.GetValue(depth + 1);
                if (subvalue > max)
                    max = subvalue;
            }
            return max;
        }

        private long greaterThan()
        {
            if(SubPackets[0].GetValue(depth + 1) > SubPackets[1].GetValue(depth + 1))
                return 1;
            return 0;
        }

        private long lessThan()
        {
            if (SubPackets[0].GetValue(depth + 1) < SubPackets[1].GetValue(depth + 1))
                return 1;
            return 0;
        }

        private long areEqual()
        {
            if (SubPackets[0].GetValue(depth + 1) == SubPackets[1].GetValue(depth + 1))
                return 1;
            return 0;
        }
    }
}
