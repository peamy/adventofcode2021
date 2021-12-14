using AdventOfCode2021.Solutions._14.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._14
{
    public class Puzzle14 : Puzzle
    {

        private Dictionary<string, long> combinationsCount;
        private Dictionary<string, long> characterCount;

        private List<TransformationRule> rules;

        public string SolvePart1(string[] input)
        {
            loadData(input);
            process(10);
            return (getMostCommon() - getLeastCommon()).ToString();
        }

        public string SolvePart2(string[] input)
        {
            loadData(input);
            process(40);
            return (getMostCommon() - getLeastCommon()).ToString();
        }

        private long getMostCommon()
        {            
            return characterCount.OrderByDescending(x => x.Value).FirstOrDefault().Value;
        }

        private long getLeastCommon()
        {
            return characterCount.OrderBy(x => x.Value).FirstOrDefault().Value;
        }


        /// <summary>
        /// iterates X amount of times over all the rules. 
        /// X being a parameter (steps)
        /// </summary>
        private void process(int steps)
        {
            for(int i = 0; i < steps; i++)
            {
                Dictionary<string, long> tmpCombinations = new Dictionary<string, long>(combinationsCount);
                foreach (TransformationRule rule in rules)
                {
                    executeRule(rule, tmpCombinations);
                }
                combinationsCount = tmpCombinations;
            }
        }

        /// <summary>
        /// executes a rule on the list
        /// Uses the original list to read from
        /// Uses a temporary list to write to (so rules don't influence eachother in the same iteration)
        /// </summary>
        private void executeRule(TransformationRule rule, Dictionary<string, long> tmpCombinations)
        {
            // return if the current rule is irrelevant.
            if (!combinationsCount.ContainsKey(rule.Combination) || combinationsCount[rule.Combination] < 1)
                return;

            // increase the amount of new combinations by the amount of times the current combination was found
            increaseValueInDict(rule.LeftCombination, tmpCombinations, combinationsCount[rule.Combination]);
            increaseValueInDict(rule.RightCombination, tmpCombinations, combinationsCount[rule.Combination]);
            // subtract the amount of found rules from the tmp list
            tmpCombinations[rule.Combination] -= combinationsCount[rule.Combination];

            // count individual characters
            increaseValueInDict(rule.insert, characterCount, combinationsCount[rule.Combination]);
        }

        /// <summary>
        /// reads the input and initialises the two lists
        /// totalCombinations will be the first line of the input
        /// rules is the transformation rules i.e. CH -> B. Made into a list of objects for ease.
        /// </summary>
        private void loadData(string[] input)
        {            
            // clear lists because otherwise part 2 fails with a number way too big
            combinationsCount = new Dictionary<string, long>();
            characterCount = new Dictionary<string, long>();
            rules = new List<TransformationRule>();

            string startString = input[0];
            for(int i = 0; i < startString.Length; i++)
            {
                increaseValueInDict(startString.Substring(i, 1), characterCount, 1);
                if (i < startString.Length - 1)
                {
                    string combination = startString.Substring(i, 2);
                    increaseValueInDict(combination, combinationsCount, 1);
                }            
            }

            for(int i = 2; i < input.Length; i++)
            {
                rules.Add(new TransformationRule(input[i]));
            }
        }

        /// <summary>
        /// increases the value in a dictionary (is used on 2 dictionaries here)
        /// put in a function so we can create they key if it does not exist
        /// </summary>
        private void increaseValueInDict(string key, Dictionary<string, long> dictionary, long value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                return;
            }
            dictionary[key] += value;
        }

    }
}
