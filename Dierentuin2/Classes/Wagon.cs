using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin2.Classes
{
    public class Wagon
    {
        private const int MaxPoints = 10;

        public List<Animal> Animals { get; private set; }

        public Wagon()
        {
            Animals = new List<Animal>();
        }

        public bool CanAddAnimal(Animal animal)
        {
            // Controleer of het toevoegen van dit dier de maximale punten zou overschrijden
            if (Animals.Sum(a => a.Points) + animal.Points > MaxPoints)
            {
                return false;
            }

            // Controleer of het dier een carnivoor is en of er al andere dieren van dezelfde of kleinere grootte in de wagon zijn
            if (animal.Diet == Diet.Carnivore && Animals.Any(a => a.Size <= animal.Size))
            {
                return false;
            }

            // Controleer of er al een carnivoor in de wagon is en het nieuwe dier niet de enige uitzondering is (klein of middelgroot carnivoor met groot herbivoor)
            if (Animals.Any(a => a.Diet == Diet.Carnivore) && !(animal.Diet == Diet.Herbivore && animal.Size == Size.Large))
            {
                return false;
            }

            return true;
        }

        public void AddAnimal(Animal animal)
        {
            if (CanAddAnimal(animal))
            {
                Animals.Add(animal);
            }
            else
            {
                throw new InvalidOperationException("Dit dier kan niet worden toegevoegd aan deze wagon.");
            }
        }
    }
}
