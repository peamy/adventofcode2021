using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions._2.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public class Puzzle2 : Puzzle
    {
        public string SolveForFile(string file)
        {
            return SolvePart1(FileManager.Load(file)).ToString();
        }

        public string SolvePart1(string[] input)
        {
            return Solve(input, new Submarine()).ToString();
        }

        public string SolvePart2(string[] input)
        {
            return Solve(input, new SubmarinePart2()).ToString();
        }

        private static int Solve(string[] input, Submarine submarine)
        {
            var movements = getMovements(input);
            foreach (var movement in movements)
            {
                submarine.Move(movement);
            }
            return submarine.Vertical * submarine.Horizontal;
        }

        public static List<Movement> getMovements(string[] input)
        {
            var movements = new List<Movement>();
            foreach(string move in input)
            {
                movements.Add(Movement.FromString(move));
            }
            return movements;
        }
    }
}
