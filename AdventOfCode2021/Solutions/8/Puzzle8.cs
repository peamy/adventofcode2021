using AdventOfCode2021.Solutions._8.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._8
{
    public class Puzzle8 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            List<Display> displays = new List<Display>();
            foreach(string sdisplay in input)
            {
                displays.Add(new Display(sdisplay));
            }

            int total1478s = 0;
            foreach(Display display in displays)
            {
                display.Decode();
                total1478s += display.Count1478s();
            }

            return total1478s.ToString();
        }

        public string SolvePart2(string[] input)
        {
            List<Display> displays = new List<Display>();
            foreach (string sdisplay in input)
            {
                displays.Add(new Display(sdisplay));
            }

            int total = 0;
            foreach (Display display in displays)
            {
                total += display.Decode();
            }

            return total.ToString();
        }
    }
}
