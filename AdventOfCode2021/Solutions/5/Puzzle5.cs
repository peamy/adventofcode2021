using AdventOfCode2021.Solutions._5.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._5
{
    public class Puzzle5 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            var system = new CoordinateSystemRevamped(input);
            return system.CountDangerZones().ToString();
        }

        public string SolvePart2(string[] input)
        {
            var system = new CoordinateSystemRevamped(input, true);
            return system.CountDangerZones().ToString();
        }
    }
}
