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
            return total.ToString();
        }

        public string SolvePart2(string[] input)
        {
            int days = 256;
            long total = 0;

            foreach (string s in input)
            {
                foreach (string number in s.Split(','))
                {
                    total += CountSelfAndChildrenEfficient(0, days - int.Parse(number));
                }
            }
            return total.ToString();
        }

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

        long[] EightDaysCache = new long[266];
        long[] ZeroDaysCahce = new long[266];
        public long CountSelfAndChildrenEfficient(int number, int days)
        {
            if (days < 0)
                return 0L;

            if (number == 8 && EightDaysCache[days] != 0)
                return EightDaysCache[days];

            if (number == 0 && ZeroDaysCahce[days] != 0)
                return ZeroDaysCahce[days];

            long children = 0;

            long reproduces = (days - number + 7) / 7;
            
            for (int i = 0; i < reproduces; i++)
            {
                int nextdays = days - 7 * i;
                nextdays -= 1;
                nextdays -= number;
                if (nextdays >= 0)
                {
                    long addition = CountSelfAndChildrenEfficient(8, nextdays);
                    children += addition;
                }                
            }             
            if(number == 8)
                EightDaysCache[days] = 1L + children;
            if (number == 0)
                ZeroDaysCahce[days] = 1L + children;

            return 1L + children;
        }
    }
}
