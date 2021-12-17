using AdventOfCode2021.Common;
using AdventOfCode2021.Solutions;
using AdventOfCode2021.Solutions._10;
using AdventOfCode2021.Solutions._11;
using AdventOfCode2021.Solutions._12;
using AdventOfCode2021.Solutions._13;
using AdventOfCode2021.Solutions._14;
using AdventOfCode2021.Solutions._15;
using AdventOfCode2021.Solutions._16;
using AdventOfCode2021.Solutions._17;
using AdventOfCode2021.Solutions._18;
using AdventOfCode2021.Solutions._19;
using AdventOfCode2021.Solutions._20;
using AdventOfCode2021.Solutions._21;
using AdventOfCode2021.Solutions._22;
using AdventOfCode2021.Solutions._23;
using AdventOfCode2021.Solutions._24;
using AdventOfCode2021.Solutions._25;
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
            //SolvePuzzle(new Puzzle2(), 2);

            //SolvePuzzle(new Puzzle3(), 3);

            //SolvePuzzle(new Puzzle4(), 4);

            //SolvePuzzle(new Puzzle5(), 5);

            //SolvePuzzle(new Puzzle6(), 6);

            //SolvePuzzle(new Puzzle7(), 7);

            //SolvePuzzle(new Puzzle8(), 8);

            //SolvePuzzle(new Puzzle9(), 9);

            //SolvePuzzle(new Puzzle10(), 10);

            //SolvePuzzle(new Puzzle11(), 11);

            //SolvePuzzle(new Puzzle12(), 12);

            //SolvePuzzle(new Puzzle13(), 13);

            //SolvePuzzle(new Puzzle14(), 14);

            //SolvePuzzle(new Puzzle15(), 15);

            SolvePuzzle(new Puzzle16(), 16);

            //SolvePuzzle(new Puzzle17(), 17);

            //SolvePuzzle(new Puzzle18(), 18);

            //SolvePuzzle(new Puzzle19(), 19);

            //SolvePuzzle(new Puzzle20(), 20);

            //SolvePuzzle(new Puzzle21(), 21);

            //SolvePuzzle(new Puzzle22(), 22);

            //SolvePuzzle(new Puzzle23(), 23);

            //SolvePuzzle(new Puzzle24(), 24);

            //SolvePuzzle(new Puzzle25(), 25);

        }

        private static void SolvePuzzle(Puzzle puzzle, int number)
        {
            //var result = puzzle.SolvePart1(FileManager.LoadPuzzle("Input.txt", number));
            //Console.WriteLine($"Puzzle {number}.1 result: {result}");
            var part2result = puzzle.SolvePart2(FileManager.LoadPuzzle("Input.txt", number));
            Console.WriteLine($"Puzzle {number}.2 result: {part2result}");
            Console.WriteLine($"");
        }
    }
}
