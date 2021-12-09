using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._9.Objects
{
    public class Location
    {
        public List<Location> Neighbours = new List<Location>();

        private List<Location> Basin;

        public int Height;

        // only does this in the "root" location
        public void CreateBasin()
        {
            Basin = new List<Location>();
            Basin.Add(this);

            for(int i = 0; i < Neighbours.Count; i++)
                if(Neighbours[i] != null)
                    Neighbours[i].AddToBasin(Basin, this);
        }

        // if this location SHOULD be added, add it.
        // Then TRY to add all the neighbours (they will check themself)
        public void AddToBasin(List<Location> basin, Location origin)
        {
            if (Height == 9 || Height < origin.Height || basin.Contains(this))
                return;
                        
            basin.Add(this);

            for (int i = 0; i < Neighbours.Count; i++)
                if (Neighbours[i] != null)
                    Neighbours[i].AddToBasin(basin, this);
        }

        public int BasinSize()
        {
            return Basin.Count;
        }
    }
}
