using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._5.Objects
{
    public class CoordinateSystem
    {
        public List<Coordinate> coordinates;

        public CoordinateSystem(string[] input, bool diagonal = false)
        {
            coordinates = new List<Coordinate>();
            foreach (string line in input)
            {
                addCoordinates(line, diagonal);
            }
        }

        private void addCoordinates(string coordinates, bool diagonal)
        {
            var twocoords = coordinates.Split(" -> ");
            var pos1 = twocoords[0];
            var pos2 = twocoords[1];

            int x1 = int.Parse(pos1.Split(',')[0]);
            int y1 = int.Parse(pos1.Split(',')[1]);

            int x2 = int.Parse(pos2.Split(',')[0]);
            int y2 = int.Parse(pos2.Split(',')[1]);

            if(x1 == x2)
            {
                // y uitrekenen
                int start = y1 > y2 ? y2 : y1;
                int end = y1 < y2 ? y2 : y1;
                for(int i = start; i <= end; i++)
                {
                    var coord = getCoord(x1, i);
                    coord.IncreaseDangerLevel();
                }
                return;
            }

            if(y1 == y2)
            {
                // x uitrekenen
                int start = x1 > x2 ? x2 : x1;
                int end = x1 < x2 ? x2 : x1;
                for (int i = start; i <= end; i++)
                {
                    var coord = getCoord(i, y1);
                    coord.IncreaseDangerLevel();
                }
                return;
            }
            if (diagonal)
            {
                int detX = x1 < x2 ? 1 : -1;
                int detY = y1 < y2 ? 1 : -1;

                int currentx = x1;
                int currenty = y1;
                while (currentx != x2)
                {                    
                    getCoord(currentx, currenty).IncreaseDangerLevel();
                    currentx += detX;
                    currenty += detY;
                }
            }
        }

        private Coordinate getCoord(int x, int y)
        {
            var coord = coordinates.Where(c => c.X == x && c.Y == y).FirstOrDefault();
            if(coord == null)
            {
                coord = new Coordinate(x, y);
                coordinates.Add(coord);
            }
            return coord;
        }

        public int CountDangerZones()
        {
            return coordinates.Where(x => x.DangerLevel >= 2).Count();
        }

    }
}

