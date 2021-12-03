using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._3
{
    public class Puzzle3
    {
        public int SolvePart1(string[] input)
        {
            var twoDarray = Make2dArray(input);
            string gamma = GetGamma(twoDarray);
            string epsilon = getEpsilon(gamma);
            int gammaInt = BinarystringToInt(gamma);
            int epsilonint = BinarystringToInt(epsilon);
            return gammaInt * epsilonint;
        }

        public int SolvePart2(string[] input)
        {
            var inputlist = input.ToList();
            int oxygen = BinarystringToInt(GetOxygen(inputlist));
            int co2 = BinarystringToInt(GetCO2(inputlist));
            return oxygen * co2;
        }

        public string GetOxygen(List<string> input)
        {
            List<string> myInput = new List<string>();
            foreach (string s in input)
                myInput.Add(s);

            int width = input[0].Length;
            for(int i = 0; i < width; i++)
            {
                myInput = filteredInput(myInput, i);
            }

            return myInput[0];
        }

        public string GetCO2(List<string> input)
        {
            List<string> myInput = new List<string>();
            foreach (string s in input)
                myInput.Add(s);

            int width = input[0].Length;
            for (int i = 0; i < width; i++)
            {                
                myInput = filteredInput(myInput, i, true);
                if (myInput.Count <= 1)
                    break;
            }

            return myInput[0];
        }

        private List<string> filteredInput(List<string> input, int index, bool leastCommon = false)
        {
            List<string> results = new List<string>();
            string mostCommon = getMostCommon(input, index, leastCommon);
            foreach(string row in input)
            {
                string sub = row.Substring(index, 1);
                if (sub == mostCommon)
                    results.Add(row);
            }

            return results;
        }

        public int BinarystringToInt(string binarystring)
        {
            int length = binarystring.Length;
            int sum = 0;
            int i = 1;
            foreach(char c in binarystring)
            {
                if (c == '1')
                {
                    sum += (int)Math.Pow(2, length - i);
                }
                i++;
            }

            return sum;
        }

        private string getEpsilon(string gamma)
        {
            string result = "";
            foreach(char c in gamma)
            {
                if (c == '0')
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }

        public string GetGamma(string[,] array)
        {
            int length = array.GetLength(1);
            string result = "";
            for(int i = 0; i < length; i++)
            {
                result += getMostCommon(array, i);
            }
            return result;
        }

        public string[,] Make2dArray(string[] input)
        {
            int width = getAllChars(input[0]).Length;

            string[,] twoDarray = new string[input.Length, width];

            for(int i = 0; i < input.Length; i++)
            {
                var splitted = getAllChars(input[i]);
                for (int j = 0; j < width; j++)
                {
                    twoDarray[i, j] = splitted[j];
                }
            }
            return twoDarray;
        }

        private string getMostCommon(string[,] array, int index)
        {
            int count0 = 0;
            int count1 = 0;

            for(int i = 0; i < array.GetLength(0); i++)
            {
                string value = array[i, index];
                if (value == "0")
                    count0++;
                else if (value == "1")
                    count1++;
            }

            return count0 > count1 ? "0" : "1";
        }

        private string getMostCommon(List<string> input, int index, bool leastCommon)
        {
            int count0 = 0;
            int count1 = 0;

            for (int i = 0; i < input.Count; i++)
            {
                string value = input[i].Substring(index, 1);
                if (value == "0")
                    count0++;
                else if (value == "1")
                    count1++;
            }
            if (leastCommon)
                return count0 <= count1 ? "0" : "1";
            return count0 > count1 ? "0" : "1";
        }

        private string[] getAllChars(string s)
        {
            int width = s.Length;
            string[] array = new string[width];
            int i = 0;
            foreach(char c in s)
            {
                array[i] = c.ToString();
                i++;
            }
            return array;
        }

    }
}
