using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._13
{
    public class Puzzle13 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            (int[,], List<string>) p = LoadData(input);            
            return solve(p.Item1, p.Item2, true).ToString();
        }

        public string SolvePart2(string[] input)
        {
            (int[,], List<string>) p = LoadData(input);
            return solve(p.Item1, p.Item2).ToString();
        }

        private int solve(int[,] coords, List<string> folds, bool onefold = false)
        {
            int[,] result = coords;
            //printResults(coords);
            foreach(string fold in folds)
            {
                
                result = Fold(result, fold);
                
                //printResults(result);
                if (onefold)
                    break;
            }
            int count = 0;
            if(!onefold)
                printResults(result);
            foreach (int value in result)
            {
                if (value > 0)
                    count++;
            }
            return count;
        }

        private int[,] Fold(int[,] result, string axis)
        {
            if (axis.Substring(0, 1) == "x")
                return FoldX(result, int.Parse(axis.Split('=')[1]));
            return FoldY(result, int.Parse(axis.Split('=')[1]));

        }

        private int[,] FoldX(int[,] result, int foldX)
        {

            int[,] tmpresult = new int[result.GetLength(0), result.GetLength(1) / 2];

            // if this happened, we'd have to fix the code
            if (result.GetLength(1) / 2 != foldX)
                Console.WriteLine("gotta fix this");

            // if this happened, we'd have to fix the code
            if (result.GetLength(1) % 2 != 1)
                Console.WriteLine("gotta fix this");

            // if this happened, we'd have to fix the code
            if (foldX < result.GetLength(1) / 2)
                Console.WriteLine("gotta fix this");

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1) / 2; j++)
                {
                    tmpresult[i, j] = result[i, j] + result[i, result.GetLength(1) - 1 -j];
                }
            }
            return tmpresult;
        }

        private int[,] FoldY(int[,] result, int foldY)
        {

            int[,] tmpresult = new int[result.GetLength(0) / 2, result.GetLength(1)];
                            
            // if this happened, we'd have to fix the code
            if(foldY < result.GetLength(0)/2)
                    Console.WriteLine("gotta fix this");

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int reali = i;
                    if (i > foldY)
                        reali = foldY - (i - foldY);
                    if(reali != foldY)
                        tmpresult[reali, j] += result[i, j];
                }
            }
            return tmpresult;
        }

        private void printResults(int[,] result)
        {
            Console.WriteLine();
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    string restring = result[i, j] == 0 ? " " : "\u25A0";
                    Console.Write(restring);
                }
            }
            Console.WriteLine();
        }

        private (int[,], List<string>) LoadData(string[] input)
        {
            List<string> coordinates = new List<string>();
            
            int highestx = 0;
            int highesty = 0;
            List<string> folds = new List<string>();
            foreach(string s in input)
            {
                if (s.Contains(","))
                {
                    int x = int.Parse(s.Split(',')[0]);
                    int y = int.Parse(s.Split(',')[1]);
                    highestx = x > highestx ? x : highestx;
                    highesty = y > highesty ? y : highesty;
                }
                else if(s.StartsWith("fold along"))
                {
                    folds.Add(s.Split(' ')[2]);
                }                
            }
            int[,] coords = new int[highesty + 1, highestx + 1];
            foreach (string s in input)
            {
                if (!s.Contains(","))
                    break;                
                int x = int.Parse(s.Split(',')[0]);
                int y = int.Parse(s.Split(',')[1]);
                coords[y, x] = 1;
            }
            return (coords, folds);
        }
    }
}
