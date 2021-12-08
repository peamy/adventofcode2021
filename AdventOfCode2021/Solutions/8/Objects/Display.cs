using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._8.Objects
{
    public class Display
    {
        public string[] numbers = new string[10];
        IDictionary<int, string> numbersDecoded = new Dictionary<int, string>();
        public string[] displaying = new string[4];
        public Display(string input)
        {
            string[] splitted = input.Split('|');
            // substring to filter too many spaces
            displaying = splitted[1].Substring(1).Split(' ');
            numbers = splitted[0].Substring(0,splitted[0].Length-1).Split(' ');
        }

        public int Count1478s()
        {
            int total = 0;
            foreach(string number in displaying)
            {
                if(new int[] { 2,3,4,7 }.Contains(number.Length))
                    total++;
            }
            return total;
        }

        // decodes the numbers and returns the display value [ x x x x ]
        public int Decode()
        {
            // 1 7 4 and 8 are easy because of unique length
            numbersDecoded[1] = numbers.Where(x => x.Length == 2).FirstOrDefault();
            numbersDecoded[7] = numbers.Where(x => x.Length == 3).FirstOrDefault();
            numbersDecoded[4] = numbers.Where(x => x.Length == 4).FirstOrDefault();
            numbersDecoded[8] = numbers.Where(x => x.Length == 7).FirstOrDefault();

            // 6 
            // has 6 characters AND
            // ONLY ONE thing from 1
            numbersDecoded[6] = numbers.Where(x => x.Length == 6 && 
            (!x.Contains(numbersDecoded[1].Substring(0, 1)) || !x.Contains(numbersDecoded[1].Substring(1, 1)))
            ).FirstOrDefault();

            // 9 
            // has 6 characters
            // is not 6 AND
            // has EVERYTHING from 4
            numbersDecoded[9] = numbers.Where(x => x.Length == 6 && !x.Equals(numbersDecoded[6]) &&
            x.Contains(numbersDecoded[4].Substring(0, 1)) &&
            x.Contains(numbersDecoded[4].Substring(1, 1)) &&
            x.Contains(numbersDecoded[4].Substring(2, 1)) &&
            x.Contains(numbersDecoded[4].Substring(3, 1))
            ).FirstOrDefault();

            // 0
            // has 6 characters
            // is not 9 or 6
            numbersDecoded[0] = numbers.Where(x => x.Length == 6 && !x.Equals(numbersDecoded[6]) && !x.Equals(numbersDecoded[9])
            ).FirstOrDefault();

            // 3
            // has 5 characters
            // has EVERYTHING from 1
            numbersDecoded[3] = numbers.Where(x => x.Length == 5 &&
            x.Contains(numbersDecoded[1].Substring(0, 1)) &&
            x.Contains(numbersDecoded[1].Substring(1, 1))
            ).FirstOrDefault();

            // 5
            // has 5 characters
            // is not 3?
            // 9 has everything from 5 (unlike 2 or 3)
            numbersDecoded[5] = numbers.Where(x => x.Length == 5 &&
            !x.Equals(numbersDecoded[3]) &&
            numbersDecoded[9].Contains(x.Substring(0, 1)) &&
            numbersDecoded[9].Contains(x.Substring(1, 1)) &&
            numbersDecoded[9].Contains(x.Substring(2, 1)) &&
            numbersDecoded[9].Contains(x.Substring(3, 1)) &&
            numbersDecoded[9].Contains(x.Substring(4, 1))
            ).FirstOrDefault();

            // 2
            // has 5 characters
            // is not 3 or 5
            numbersDecoded[2] = numbers.Where(x => x.Length == 5 &&
            !x.Equals(numbersDecoded[3]) && !x.Equals(numbersDecoded[5])
            ).FirstOrDefault();

            int result = 0;
            for(int i = 0; i < 4; i++)
            {
                // 1st number is in 1000's 2nd in 100's 3rd in 10's and 4th just itself
                int factor = (int) Math.Pow(10, 3 - i);
                int number = numbersDecoded.Where(x => StringCompare(x.Value,displaying[i])).FirstOrDefault().Key;
                result += number * factor;
            }

            return result;
        }

        // numbers can be the same, but with different order of characters
        public static bool StringCompare(string s1, string s2)
        {
            if(s1.Length != s2.Length)
                return false;
            foreach (char c in s1)
                if (!s2.Contains(c))
                    return false;
            return true;
        }
    }
}
