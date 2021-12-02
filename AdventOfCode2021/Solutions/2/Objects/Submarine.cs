using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._2.Objects
{
    class Submarine
    {
        public int Horizontal { get { return horizontal; } }
        protected int horizontal = 0;
        public int Vertical { get { return vertical; } }
        protected int vertical = 0;

        public virtual void Move(Movement movement)
        {
            switch (movement.direction)
            {
                case Movement.Direction.DOWN:
                    vertical += movement.distance;
                    break;
                case Movement.Direction.UP:
                    vertical -= movement.distance;
                    break;
                case Movement.Direction.FORWARD:
                    horizontal += movement.distance;
                    break;
            }
        }
    }
}
