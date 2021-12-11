using AdventOfCode2021.Solutions._11.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._11
{
    public class Puzzle11 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            var octopi = initialiseOctopi(input);
            setNeighbours(octopi);
            for (int i = 0; i < 100; i++)
            {
                foreach(Octopus octo in octopi)
                {
                    octo.FirstStep();
                }
                //visualiseOctopi(octopi);
                foreach (Octopus octo in octopi)
                {
                    octo.FinalStep();
                }
            }
            int totalFlashes = 0;
            foreach(Octopus octo in octopi)
            {
                totalFlashes += octo.AmountOfFlashes;
            }

            return totalFlashes.ToString();
        }

        public string SolvePart2(string[] input)
        {
            var octopi = initialiseOctopi(input);
            setNeighbours(octopi);
            int count = 0;
            bool allFlashed = false;
            while (!allFlashed)
            {
                foreach (Octopus octo in octopi)
                {
                    octo.FirstStep();
                }
                allFlashed = true;
                //visualiseOctopi(octopi);
                foreach (Octopus octo in octopi)
                {                    
                    if (!octo.FinalStep())
                        allFlashed = false;
                }
                count++;
            }

            return count.ToString();
        }

        private Octopus[,] initialiseOctopi(string[] input)
        {
            Octopus[,] octopi = new Octopus[10,10];
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < input[0].Length; j++)
                {
                    octopi[i, j] = new Octopus() { Value = int.Parse(input[i].Substring(j, 1)) };
                }
            }
            return octopi;
        }

        private void setNeighbours(Octopus[,] octopi)
        {
            for (int i = 0; i < octopi.GetLength(0); i++)
            {
                for (int j = 0; j < octopi.GetLength(1); j++)
                {
                    TryAddNeigbour(octopi[i, j], octopi, i + 1, j);
                    TryAddNeigbour(octopi[i, j], octopi, i - 1, j);
                    TryAddNeigbour(octopi[i, j], octopi, i, j + 1);
                    TryAddNeigbour(octopi[i, j], octopi, i + 1, j + 1);
                    TryAddNeigbour(octopi[i, j], octopi, i - 1, j + 1);
                    TryAddNeigbour(octopi[i, j], octopi, i + 1, j - 1);
                    TryAddNeigbour(octopi[i, j], octopi, i - 1, j - 1);
                    TryAddNeigbour(octopi[i, j], octopi, i, j - 1);
                }
            }
        }

        private void TryAddNeigbour(Octopus octopus, Octopus[,] octopi, int i, int j)
        {
            if (i < 0 || j < 0 || i >= octopi.GetLength(0) || j >= octopi.GetLength(1))
                return;
            octopus.AddNeigbour(octopi[i, j]);
        }

        private void visualiseOctopi(Octopus[,] octopi)
        {            
            Console.WriteLine();            
            for (int i = 0; i < octopi.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("");
                Console.WriteLine();
                for (int j = 0; j < octopi.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (octopi[i, j].hasFlashed)
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(octopi[i, j].ValueVisualize);
                    
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("");
            Console.WriteLine();
        }

    }
}
