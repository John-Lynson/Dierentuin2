using Dierentuin2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin2.Classes
{
    public class Train
    {
        public List<Wagon> Wagons { get; private set; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public void AddWagon(Wagon wagon)
        {
            Wagons.Add(wagon);
        }

        public int CalculateTotalCapacity()
        {
            return Wagons.Sum(w => w.Animals.Sum(a => a.Points));
        }
    }
}