using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._14.Objects
{
    public class TransformationRule
    {
        public string Combination;
        public string insert;
        public string LeftCombination
        {
            get
            {
                return $"{Combination.Substring(0,1)}{insert}";
            }
        }

        public string RightCombination
        {
            get
            {
                return $"{insert}{Combination.Substring(1, 1)}";
            }
        }

        public TransformationRule(string input)
        {
            var split = input.Split(" -> ");
            Combination = split[0];
            insert = split[1];
        }
    }
}
