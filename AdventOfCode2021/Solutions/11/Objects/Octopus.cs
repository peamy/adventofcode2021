using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._11.Objects
{
    public class Octopus
    {
        public int Value;
        public int ValueVisualize
        {
            get
            {
                if (Value > 9)
                    return 9;
                return Value;
            }
        }
        public List<Octopus> Adjecent = new List<Octopus>();
        public int AmountOfFlashes = 0;
        public bool hasFlashed = false;

        public void AddNeigbour(Octopus neighbour)
        {
            if (Adjecent.Contains(neighbour) || neighbour.Equals(this))
                return;
            Adjecent.Add(neighbour);
        }

        public void FirstStep()
        {
            this.IncreaseCount();
        }

        public void IncreaseCount()
        {
            Value += 1;
            TryFlash();
        }

        public void TryFlash()
        {
            if (hasFlashed)
                return;
            if(this.Value > 9)
            {
                hasFlashed = true;
                flash();
            }
        }

        private void flash()
        {
            AmountOfFlashes++;
            foreach(Octopus octo in Adjecent)
            {
                octo.IncreaseCount();
            }
        }

        public bool FinalStep()
        {            
            if (hasFlashed)
            {
                hasFlashed = false;
                Value = 0;
                return true;
            }
            return false;                
        }
    }
}
