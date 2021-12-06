using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._6
{
    public class Puzzle6 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            int days = 80;
            long total = 0;

            foreach (string s in input)
            {
                foreach(string number in s.Split(','))
                {
                    total += CountSelfAndChildrenEfficient(0, days - int.Parse(number));
                }
            }
            return solve(input, 80);
        }

        public string SolvePart2(string[] input)
        {
            return solve(input, 256);
        }

        private string solve(string[] input, int days)
        {
            long total = 0;

            foreach (string s in input)
            {
                foreach (string number in s.Split(','))
                {
                    // kind of a cheat, but we don't start at day 80.
                    // Each fish starts at the first day where they will reproduce
                    // tbh couldve made a calculation for each of the numbers (0-6)
                    // count each of them, and multiply by their value;
                    total += CountSelfAndChildrenEfficient(0, days - int.Parse(number));
                }
            }
            return total.ToString();
        }

        // legacy
        //public int CountSelfAndChildren(int number, int days)
        //{
        //    if (days < 0)
        //        return 0;

        //    int children = 0;

        //    int reproduces = (days - number + 7) / 7;
        //    for(int i = 0; i < reproduces; i++)
        //    {
        //        int nextdays = days - 7 * i;
        //        nextdays -= 1;
        //        nextdays -= number;
        //        if(nextdays >= 0)
        //            children += CountSelfAndChildren(8, nextdays);
        //    }

        //    return 1 + children;
        //}

        // most of the calculations will be done on the number 8
        // therefore I will cache the results of all those calculations
        // only the "root" numbers will have no cache
        long[] EightDaysCache = new long[257];
        // returns 1 if they have no children
        public long CountSelfAndChildrenEfficient(int number, int days)
        {
            // if the result is already calculated before, return that value.            
            if (number == 8 && EightDaysCache[days] != 0)
                return EightDaysCache[days];

            long children = 0;

            // this is the amount of children this fish will make over the course if X days
            long reproduces = (days - number + 7) / 7;            
            for (int i = 0; i < reproduces; i++)
            {
                int nextdays = days - 7 * i; // for every day of the week we go a week further
                nextdays -= 1; // -1 because they will start NEXT day
                nextdays -= number; // Will start AFTER this fish starts reproducing
                // if there are days left for my children to reproduce, add their children to the count.
                if (nextdays >= 0)
                {                    
                    long addition = CountSelfAndChildrenEfficient(8, nextdays);
                    children += addition;
                }                
            }             
            // save the calculated number to the cache
            if(number == 8)
                EightDaysCache[days] = 1L + children;

            return 1L + children;
        }
    }
}
