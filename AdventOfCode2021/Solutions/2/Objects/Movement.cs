using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._2.Objects
{
    public class Movement
    {
        public enum Direction
        {
            UNKNOWN, UP, DOWN, FORWARD
        }

        public Direction direction;
        public int distance;

        public static Movement FromString(string movementString)
        {
            Direction direction = Direction.UNKNOWN;
            
            string[] split = movementString.Split(' ');
            // split[0] is the direction
            switch (split[0]){ 
                case "up":
                    direction = Direction.UP;
                    break;
                case "down":
                    direction = Direction.DOWN;
                    break;
                case "forward":
                    direction = Direction.FORWARD;
                    break;
                default:
                    break;
            }

            int distance = int.Parse(split[1]);

            return new Movement()
            {
                direction = direction,
                distance = distance
            };
        }

    }
}
