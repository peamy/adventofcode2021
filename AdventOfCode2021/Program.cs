using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {

            var puzzle2result = Puzzle2.SolvePart1(FileManager.LoadP2("Input.txt"));
            Console.WriteLine($"Puzzle 2.1 result: {puzzle2result}");
            var puzzle2part2reslt = Puzzle2.SolvePart2(FileManager.LoadP2("Input.txt"));
            Console.WriteLine($"Puzzle 2.2 result: {puzzle2part2reslt}");
        }
    }
}
