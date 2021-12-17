using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._16.Objects
{
    public abstract class Packet
    {
        public int Version;
        public int Id;
        public string packetStr;
        public long value = -1;
        public abstract long GetValue(int depth = 0);       
    }
}
