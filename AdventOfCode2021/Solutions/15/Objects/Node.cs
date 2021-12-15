using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._15.Objects
{
    public class Node
    {
        public int RiskLevel;
        public bool isEndNode = false;
        public List<Node> NeighBours = new List<Node>();
        public int ShortestToStart = int.MaxValue;
        public bool isChecked = false;

        public bool SetShortestToStart(int shortest)
        {
            if(shortest < ShortestToStart)
            {
                ShortestToStart = shortest;
                return true;
            }
            return false;
        }
    }
}
