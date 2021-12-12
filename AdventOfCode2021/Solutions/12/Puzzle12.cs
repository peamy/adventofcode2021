using AdventOfCode2021.Solutions._12.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._12
{
    public class Puzzle12 : Puzzle
    {
        private List<Cave> caves = new List<Cave>();
        public string SolvePart1(string[] input)
        {
            InitialiseCaves(input);
            return CalculateNrOfRoutes(false).ToString();
        }

        public string SolvePart2(string[] input)
        {
            InitialiseCaves(input);
            return CalculateNrOfRoutes(true).ToString();
        }

        public int CalculateNrOfRoutes(bool canVisitSmallTwice)
        {
            Cave start = caves.Where(c => c.Name == "start").FirstOrDefault();

            return start.CalculatePossibleRoutes(new List<string>(), canVisitSmallTwice);
        }

        public void InitialiseCaves(string[] input) 
        {
            foreach (string connections in input)
            {
                string cave1str = connections.Split('-')[0];
                string cave2str = connections.Split('-')[1];
                var cave1 = caves.Where(c => c.Name == cave1str).FirstOrDefault();
                if (cave1 == null)
                {
                    cave1 = new Cave(cave1str);
                    caves.Add(cave1);
                }
                var cave2 = caves.Where(c => c.Name == cave2str).FirstOrDefault();
                if (cave2 == null)
                {
                    cave2 = new Cave(cave2str);
                    caves.Add(cave2);
                }
                cave1.AddNeigbour(cave2);
                cave2.AddNeigbour(cave1);
            }
        }
    }
}
