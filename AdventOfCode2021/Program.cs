using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions;
using AdventOfCode2021.Solutions._3;
using AdventOfCode2021.Solutions._4;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {

            var puzzle2 = new Puzzle2();
            SolvePuzzle(puzzle2, 2);

            var puzzle3 = new Puzzle3();
            SolvePuzzle(puzzle3, 3);

            var puzzle4 = new Puzzle4();
            SolvePuzzle(puzzle4, 4);
        }

        private static void SolvePuzzle(Puzzle puzzle, int number)
        {
            var result = puzzle.SolvePart1(FileManager.LoadPuzzle("Input.txt", number));
            Console.WriteLine($"Puzzle {number}.1 result: {result}");
            var part2result = puzzle.SolvePart2(FileManager.LoadPuzzle("Input.txt", number));
            Console.WriteLine($"Puzzle {number}.2 result: {part2result}");
            Console.WriteLine($"");
        }
    }
}
