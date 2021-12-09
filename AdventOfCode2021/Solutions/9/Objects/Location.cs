using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._9.Objects
{
    public class Location
    {
        public Location UpNeighbour;
        public Location DownNeighbour;
        public Location LeftNeigbour;
        public Location RightNeighbour;

        private List<Location> Basin;

        public int Height;

        public void CreateBasin()
        {
            Basin = new List<Location>();
            Basin.Add(this);
            if (UpNeighbour != null)
                UpNeighbour.AddToBasin(Basin, this);
            if (DownNeighbour != null)
                DownNeighbour.AddToBasin(Basin, this);
            if (LeftNeigbour != null)
                LeftNeigbour.AddToBasin(Basin, this);
            if (RightNeighbour != null)
                RightNeighbour.AddToBasin(Basin, this);
        }

        public void AddToBasin(List<Location> basin, Location origin)
        {
            if (Height == 9 || Height < origin.Height)
                return;
            if (!neighboursOk(origin))
                return;
            
            if(!basin.Contains(this))
                basin.Add(this);
            infectNeigbour(basin, UpNeighbour, origin);
            infectNeigbour(basin, DownNeighbour, origin);
            infectNeigbour(basin, LeftNeigbour, origin);
            infectNeigbour(basin, RightNeighbour, origin);
        }

        private void infectNeigbour(List<Location> basin, Location neighbour, Location origin)
        {
            if(neighbour != null && !neighbour.Equals(origin))
            {
                neighbour.AddToBasin(basin, this);
            }
        }

        private bool neighboursOk(Location origin)
        {
            return true;
        }

        public int BasinSize()
        {
            return Basin.Count;
        }
    }
}
