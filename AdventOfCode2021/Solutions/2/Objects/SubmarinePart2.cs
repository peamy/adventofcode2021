using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._2.Objects
{
    class SubmarinePart2 : Submarine
    {
        private int aim = 0;
                
        public override void Move(Movement movement)
        {
            switch (movement.direction)
            {
                case Movement.Direction.DOWN:
                    aim += movement.distance;
                    break;
                case Movement.Direction.UP:
                    aim -= movement.distance;
                    break;
                case Movement.Direction.FORWARD:
                    vertical += aim * movement.distance;
                    horizontal += movement.distance;
                    break;
            }
        }
    }
}
