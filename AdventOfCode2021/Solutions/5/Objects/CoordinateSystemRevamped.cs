using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._5.Objects
{
    public class CoordinateSystemRevamped
    {
        // could calculate size based on biggest x and biggest y but heck it
        public int[,] CoordinateGrid = new int[1000, 1000];
        private int dangerzones = 0;
        public CoordinateSystemRevamped(string[] input, bool diagonal = false)
        {
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

            if (x1 == x2)
            {
                // y uitrekenen
                int start = y1 > y2 ? y2 : y1;
                int end = y1 < y2 ? y2 : y1;
                for (int i = start; i <= end; i++)
                {
                    CoordinateGrid[x1,i] += 1;
                    if (CoordinateGrid[x1, i] == 2)
                        dangerzones++;
                }
                return;
            }

            if (y1 == y2)
            {
                // x uitrekenen
                int start = x1 > x2 ? x2 : x1;
                int end = x1 < x2 ? x2 : x1;
                for (int i = start; i <= end; i++)
                {
                    CoordinateGrid[i,y1] += 1;
                    if (CoordinateGrid[i, y1] == 2)
                        dangerzones++;
                }
                return;
            }
            if (diagonal)
            {
                int currentX = x1;
                int currentY = y1;

                int detX = x1 < x2 ? 1 : -1;
                int detY = y1 < y2 ? 1 : -1;

                while(currentX != x2)
                {
                    CoordinateGrid[currentX, currentY] += 1;
                    if (CoordinateGrid[currentX, currentY] == 2)
                        dangerzones++;
                    currentX += detX;
                    currentY += detY;
                }
                // because we exit the while one iteration too soon :')
                // couldve calculated the number of coordinates and use for loop which would look nicer
                CoordinateGrid[currentX, currentY] += 1;
                if (CoordinateGrid[currentX, currentY] == 2)
                    dangerzones++;
            }
        }

        public int CountDangerZones()
        {
            return dangerzones;
        }
    }
}
