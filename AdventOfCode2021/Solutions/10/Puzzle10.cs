using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._10
{
    public class Puzzle10 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            int total = 0;
            foreach (string s in input)
            {
                total += FindFirsIllegal(s);
            }
            return total.ToString();
        }
        private Dictionary<char, char> characterPairs = new Dictionary<char, char>() { { '{', '}' }, { '(', ')' }, { '[', ']' }, { '<', '>' } };
        private string closingStrings = ">]})";

        public int FindFirsIllegal(string input)
        {
            // stack expectednext
            Stack<char> expectedClosings = new Stack<char>();

            foreach(char c in input)
            {
                if (closingStrings.Contains(c))
                {
                    if (expectedClosings.Peek() != c)
                        return getCharValue(c);
                    expectedClosings.Pop();
                }
                else
                {
                    expectedClosings.Push(characterPairs.GetValueOrDefault(c));
                }                    
            }
            return 0;
        }

        private int getCharValue(char c)
        {
            switch (c)
            {
                case '}':
                    return 1197;
                case ']':
                    return 57;
                case ')':
                    return 3;
                case '>':
                    return 25137;
                default:
                    return 0;
            }
        }

        private int getCharValuePt2(char c)
        {
            switch (c)
            {
                case '}':
                    return 3;
                case ']':
                    return 2;
                case ')':
                    return 1;
                case '>':
                    return 4;
                default:
                    return 0;
            }
        }

        public string SolvePart2(string[] input)
        {
            List<long> scores = new List<long>();
            foreach (string s in input)
            {
                long score = FixSyntaxIllegal(s);
                if (score > 0)
                    scores.Add(score);
            }
            scores.Sort();
            return scores[scores.Count/2].ToString();
        }

        public long FixSyntaxIllegal(string input)
        {
            Stack<char> expectedClosings = new Stack<char>();

            foreach (char c in input)
            {
                if (closingStrings.Contains(c))
                {
                    if (expectedClosings.Peek() != c)
                        return 0;
                    expectedClosings.Pop();
                }
                else
                {
                    expectedClosings.Push(characterPairs.GetValueOrDefault(c));
                }
            }
            long totalscore = 0;
            while(expectedClosings.Count > 0){
                totalscore = totalscore * 5;
                totalscore += getCharValuePt2(expectedClosings.Pop());
            }

            return totalscore;
        }
    }
}
