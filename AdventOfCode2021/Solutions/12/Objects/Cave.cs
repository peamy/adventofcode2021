using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._12.Objects
{
    public class Cave
    {
        public string Name;
        public bool IsBigCave = false;
        public List<Cave> Neigbours = new List<Cave>();
        public Cave(string name)
        {
            this.Name = name;
            if (name.ToUpper() == name)
                IsBigCave = true;
        }

        public void AddNeigbour(Cave cave)
        {
            if (this.Neigbours.Contains(cave))
                return;
            Neigbours.Add(cave);
        }

        public int CalculatePossibleRoutes(List<string> trace, bool canVisitSmallCave)
        {
            if (!IsBigCave && trace.Contains(Name))
            {
                if (!canVisitSmallCave || Name == "start")
                    return 0;
                canVisitSmallCave = false;
            }
                
            trace.Add(Name);

            if (Name == "end")
            {
                //printList(trace);
                return 1;
            }                

            int subcaves = 0;

            foreach(Cave neighbour in Neigbours)
            {
                subcaves += neighbour.CalculatePossibleRoutes(new List<string>(trace), canVisitSmallCave);
            }

            return subcaves;
        }

        private static void printList(List<string> list)
        {
            string total = "";
            foreach(string s in list)
            {
                total += $"{s}, ";
            }
            Console.WriteLine(total);
        }
    }
}
