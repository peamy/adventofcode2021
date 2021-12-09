using AdventOfCode2021.Solutions._9.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._9
{
    public class Puzzle9 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            Field field = new Field(input);
            return field.FindBottoms().ToString();
        }

        public string SolvePart2(string[] input)
        {
            Field field = new Field(input);
            return field.ThreeBiggestBasins().ToString();
        }
              
        

    }
}
