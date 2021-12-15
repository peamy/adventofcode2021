using AdventOfCode2021.Solutions._15.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._15
{
    public class Puzzle15 : Puzzle
    {
        public string SolvePart1(string[] input)
        {
            var (startNode, endNode) = LoadData(input);
            PathCalculator pc = new PathCalculator(startNode, endNode);
            return pc.CalculateShortestPath().ToString();
        }

        public string SolvePart2(string[] input)
        {
            var (startNode, endNode) = LoadDataPt2(input);
            PathCalculator pc = new PathCalculator(startNode, endNode);
            return pc.CalculateShortestPath().ToString();
        }

        //private int[,] LoadData(string[] input)
        //{
        //    int[,] grid = new int[input.Length, input[0].Length];
        //    for (int i = 0; i < input.Length; i++)
        //   {
        //        for(int j = 0; j < input[0].Length; j++)
        //        {
        //            grid[i, j] = int.Parse(input[i].Substring(j, 1));
        //        }
        //    }
        //    return grid;
        //}
        public (Node, Node) LoadData(string[] input)
        {
            Node[,] nodes = new Node[input.Length, input[0].Length];
            Node startNode = new Node();
            Node endNode = new Node();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    var node = new Node() { RiskLevel = int.Parse(input[i].Substring(j, 1)) };
                    if (i == 0 && j == 0)
                    {
                        startNode = node;
                        node.ShortestToStart = 0;
                    }
                    if (i == input.Length - 1 && j == input[0].Length - 1)
                    {
                        node.isEndNode = true;
                        endNode = node;
                    }
                    nodes[i, j] = node;
                }
            }
            setNeigbours(nodes);
            return (startNode, endNode);
        }

        public (Node, Node) LoadDataPt2(string[] input)
        {
            Node[,] nodes = new Node[(input.Length*5), (input[0].Length*5)];
            Node startNode = new Node();
            Node endNode = new Node();
            for (int ii = 0; ii < 5; ii++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int jj = 0; jj < 5; jj++)
                    {
                        for (int j = 0; j < input[0].Length; j++)
                        {                        
                            var node = new Node() { RiskLevel = GetRiskLevel(input[i].Substring(j, 1), ii, jj) };
                            if (i == 0 && j == 0 && ii ==0 && jj == 0)
                            {
                                startNode = node;
                                node.ShortestToStart = 0;
                            }
                            if (i == input.Length - 1 && j == input[0].Length - 1 && ii == 4 && jj == 4)
                            {
                                node.isEndNode = true;
                                endNode = node;
                            }
                            nodes[(input.Length * ii) + i, (input[0].Length * jj) + j] = node;
                        }
                    }
                }
            }
            setNeigbours(nodes);
            return (startNode, endNode);
        }

        public int GetRiskLevel(string input, int ii, int jj)
        {
            var number = int.Parse(input);
            number += ii + jj;
            if (number > 9)
                number -= 9;
            return number;
        }

        private void setNeigbours(Node[,] nodes)
        {
            for (int i = 0; i < nodes.GetLength(0); i++)
            {
                for (int j = 0; j < nodes.GetLength(0); j++)
                {
                    setNeigbour(nodes, nodes[i, j], i, j - 1);
                    setNeigbour(nodes, nodes[i, j], i, j + 1);
                    setNeigbour(nodes, nodes[i, j], i + 1, j);
                    setNeigbour(nodes, nodes[i, j], i - 1, j);
                    // diagonally
                    //setNeigbour(nodes, nodes[i, j], i - 1, j + 1);
                    //setNeigbour(nodes, nodes[i, j], i + 1, j - 1);
                    //setNeigbour(nodes, nodes[i, j], i + 1, j + 1);
                    //setNeigbour(nodes, nodes[i, j], i - 1, j - 1);
                }
            }
        }

        private void setNeigbour(Node[,] nodes, Node node, int i, int j)
        {
            if (i < 0 || j < 0 || i >= nodes.GetLength(0) || j >= nodes.GetLength(1))
                return;
            node.NeighBours.Add(nodes[i, j]);
        }
    }

}
