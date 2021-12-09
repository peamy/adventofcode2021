using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._9.Objects
{
    public class Field
    {
        public Location[,] locations;
        private List<Location> startLocations;
        private string[] input;

        public Field(string[] input)
        {
            this.input = input;
            locations = new Location[input.Length, input[0].Length]; 
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    locations[i, j] = new Location() { Height = GetLocationValue(input, i, j) };
                    if(i != 0)
                    {
                        locations[i, j].Neighbours.Add(locations[i - 1, j]);
                        locations[i - 1, j].Neighbours.Add(locations[i, j]);
                    }
                    if(j != 0)
                    {
                        locations[i, j].Neighbours.Add(locations[i, j - 1]);
                        locations[i, j - 1].Neighbours.Add(locations[i, j]);
                    }
                }
            }
        }

        public void StartCreatingBasins()
        {
            foreach(Location bottom in startLocations)
            {
                bottom.CreateBasin();
            }
        }

        // calculate the three biggest basins and add them together
        public int ThreeBiggestBasins()
        {
            FindBottoms();
            StartCreatingBasins();

            int[] biggest = new int[] { 0, 0, 0 };

            foreach (Location bottom in startLocations)
            {
                biggest = getBiggestThree(bottom.BasinSize(), biggest);
            }

            return biggest[0] * biggest[1] * biggest[2];
        }

        // ugly code to keep a top 3 of numbers. Didn't want to bother with sorting algorythms
        public static int[] getBiggestThree(int input, int[] currentBiggest)
        {
            int smallest = currentBiggest[0];
            int smallestIndex = 0;
            if(currentBiggest[1] < currentBiggest[0])
            {
                smallestIndex = 1;
                smallest = currentBiggest[1];
            }                
            if(currentBiggest[2] < smallest)
            {
                smallestIndex = 2;
                smallest = currentBiggest[2];
            }
            if (input > smallest)
                currentBiggest[smallestIndex] = input;
            return currentBiggest;
        }

        // calculates part 1 solution. Also creates a list of bottoms to be used in part 2
        public int FindBottoms()
        {
            startLocations = new List<Location>();
            int total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    int location = GetLocationValue(input, i, j);
                    int left = GetLocationValue(input, i, j - 1);
                    int right = GetLocationValue(input, i, j + 1);
                    int up = GetLocationValue(input, i - 1, j);
                    int down = GetLocationValue(input, i + 1, j);
                    if (location < up &&
                        location < down &&
                        location < left &&
                        location < right)
                    {
                        total += location + 1;
                        startLocations.Add(locations[i, j]);
                    }                        
                }
            }
            return total;
        }

        // get numeric value from input on specific location
        public static int GetLocationValue(string[] input, int y, int x)
        {
            if (x < 0 || y < 0 || x >= input[0].Length || y >= input.Length)
                return 10;
            return int.Parse(input[y].Substring(x, 1));
        }
    }
}
