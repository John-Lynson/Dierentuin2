using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin2.Classes
{
    public enum Size { Small = 1, Medium = 3, Large = 5 }
    public enum Diet { Herbivore, Carnivore }

    public class Animal
    {
        public string Name { get; private set; }
        public Size Size { get; private set; }
        public Diet Diet { get; private set; }

        public Animal(string name, Diet diet, Size size)
        {
            Name = name;
            Diet = diet;
            Size = size;
        }

        public int Points
        {
            get
            {
                return (int)this.Size;
            }
        }
    }
}
