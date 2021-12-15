using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._15.Objects
{
    public class PathCalculator
    {
        private Node startNode;
        private Node endNode;
        public PathCalculator(Node start, Node end)
        {
            startNode = start;
            endNode = end;
        }

        public int CalculateShortestPath()
        {
            prioQueue.Add(startNode);
            return calculateShortest();            
        }

        public List<Node> prioQueue = new List<Node>();
        private int calculateShortest()
        {
            while (prioQueue.Any())
            {
                prioQueue = prioQueue.OrderBy(x => x.ShortestToStart).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);
                foreach(var neigbour in node.NeighBours)
                {                    
                    neigbour.SetShortestToStart(node.ShortestToStart + neigbour.RiskLevel);
                    if(!prioQueue.Contains(neigbour) && !neigbour.isChecked)
                        prioQueue.Add(neigbour);
                }
                node.isChecked = true;
                if (node.isEndNode)
                    return node.ShortestToStart;
            }            
            return -1;
        }

    }
}
