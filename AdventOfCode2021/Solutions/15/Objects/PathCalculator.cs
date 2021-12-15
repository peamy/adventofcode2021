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
        /// <summary>
        /// This function was inspired by the following website
        /// https://www.codeproject.com/Articles/1221034/Pathfinding-Algorithms-in-Csharp
        /// Using Dijkstra's shortest path algorithm
        /// 
        /// Fun fact, before using dijkstra I had already started a solution using a linkedlist of Nodes
        /// However this solution was very inefficient and I killed the test after about 2 minutes.
        /// That's when I looked up pathfinding algorithms (Dijkstra)
        /// </summary>
        /// <returns>The length of the shortest path, not the path itself</returns>
        public static int CalculateShortestPath(Node startNode)
        {
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(startNode);
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
