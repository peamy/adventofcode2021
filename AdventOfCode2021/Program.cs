using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions;
using AdventOfCode2021.Solutions._3;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {

            var puzzle2result = Puzzle2.SolvePart1(FileManager.LoadPuzzle("Input.txt", 2));
            Console.WriteLine($"Puzzle 2.1 result: {puzzle2result}");
            var puzzle2part2reslt = Puzzle2.SolvePart2(FileManager.LoadPuzzle("Input.txt", 2));
            Console.WriteLine($"Puzzle 2.2 result: {puzzle2part2reslt}");


            var puzzle3 = new Puzzle3();
            var puzzle3result = puzzle3.SolvePart1(FileManager.LoadPuzzle("Input.txt", 3));
            Console.WriteLine($"Puzzle 3.1 result: {puzzle3result}");
            var puzzle3part2reslt = puzzle3.SolvePart2(FileManager.LoadPuzzle("Input.txt", 3));
            Console.WriteLine($"Puzzle 3.2 result: {puzzle3part2reslt}");
        }
    }
}
