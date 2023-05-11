using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin2.Classes
{
    public class Distribution
    {
        public Train Train { get; private set; }

        public Distribution()
        {
            Train = new Train();
        }

        public void AddAnimal(Animal animal)
        {
            foreach (var wagon in Train.Wagons)
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    return;
                }
            }

            var newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            Train.AddWagon(newWagon);
        }
    }
}
