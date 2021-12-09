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
                }
            }
            addNeigbours();
        }        

        private void addNeigbours()
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if(i != 0)
                    {
                        locations[i, j].UpNeighbour = locations[i - 1, j];
                    }
                    if(j != 0)
                    {
                        locations[i, j].LeftNeigbour = locations[i, j - 1];
                    }
                    if(i < input.Length - 1)
                    {
                        locations[i, j].DownNeighbour = locations[i + 1, j];
                    }
                    if (j < input[0].Length - 1)
                    {
                        locations[i, j].RightNeighbour = locations[i, j + 1];
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

        public static int GetLocationValue(string[] input, int y, int x)
        {
            if (x < 0 || y < 0 || x >= input[0].Length || y >= input.Length)
                return 10;
            return int.Parse(input[y].Substring(x, 1));
        }
    }
}
