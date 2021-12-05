using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._5.Objects
{
    public class Coordinate
    {
        public int X;
        public int Y;
        public int DangerLevel;

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
            DangerLevel = 0;
        }

        public void IncreaseDangerLevel()
        {
            DangerLevel++;
        }
    }
}
