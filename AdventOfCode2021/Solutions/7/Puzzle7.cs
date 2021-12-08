using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._7
{
    public class Puzzle7 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            return mostEfficientCrabRave(input[0]).ToString();
        }

        public string SolvePart2(string[] input)
        {
            return mostEfficientCrabRave(input[0], true).ToString();
        }

        private int highestNumber = 0;
        private int mostEfficientCrabRave(string input, bool part2 = false)
        {
            int[] crabs = getCrabsIntAndSetHighest(input);
            int lowestFuel = int.MaxValue;
            for(int i = 0; i < highestNumber; i++)
            {
                int fuel = calculateFuel(crabs, i, part2);
                if (fuel < lowestFuel)
                    lowestFuel = fuel;
            }
            
            return lowestFuel;
        }

        private int calculateFuel(int[] crabs, int target, bool part2)
        {
            int totalfuel = 0;
            foreach(int crab in crabs)
            {
                int fuelkost = Math.Abs(crab - target);
                if (part2)
                    fuelkost = GetFuelKostPt2(fuelkost);
                totalfuel += fuelkost;
            }
            return totalfuel;
        }

        public int GetFuelKostPt2(int distance)
        {            
            return distance * (distance+1) / 2 ;
        }

        private int[] getCrabsIntAndSetHighest(string input)
        {
            var crabarray = input.Split(',');
            int[] crabs = new int[crabarray.Length];
            for (int i = 0; i < crabarray.Length; i++)
            {
                crabs[i] = int.Parse(crabarray[i]);
                if (crabs[i] > highestNumber)
                    highestNumber = crabs[i];
            }
            return crabs;
        }
    }
}
