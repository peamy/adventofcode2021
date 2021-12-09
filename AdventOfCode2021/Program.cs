using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions;
using AdventOfCode2021.Solutions._3;
using AdventOfCode2021.Solutions._4;
using AdventOfCode2021.Solutions._5;
using AdventOfCode2021.Solutions._6;
using AdventOfCode2021.Solutions._7;
using AdventOfCode2021.Solutions._8;
using AdventOfCode2021.Solutions._9;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {

            SolvePuzzle(new Puzzle2(), 2);

            SolvePuzzle(new Puzzle3(), 3);

            SolvePuzzle(new Puzzle4(), 4);

            SolvePuzzle(new Puzzle5(), 5);

            SolvePuzzle(new Puzzle6(), 6);

            SolvePuzzle(new Puzzle7(), 7);

            SolvePuzzle(new Puzzle8(), 8);

            SolvePuzzle(new Puzzle9(), 9);

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
