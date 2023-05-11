using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin2.Classes
{
    public class UI
    {
        private Distribution distribution;

        public UI()
        {
            distribution = new Distribution();
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Voeg een dier toe");
                Console.WriteLine("2. Toon wagons");
                Console.WriteLine("3. Stop");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddAnimal();
                        break;
                    case 2:
                        DisplayWagons();
                        break;
                    case 3:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
        }

        private void AddAnimal()
        {
            Console.WriteLine("Voer de naam van het dier in:");
            string name = Console.ReadLine();

            Console.WriteLine("Voer het dieet van het dier in (1 voor herbivoor, 2 voor carnivoor):");
            int dietChoice = int.Parse(Console.ReadLine());
            Diet diet = dietChoice == 1 ? Diet.Herbivore : Diet.Carnivore;

            Console.WriteLine("Voer de grootte van het dier in (1 voor klein, 3 voor middelgroot, 5 voor groot):");
            int sizeInput = int.Parse(Console.ReadLine());
            Size size;
            switch (sizeInput)
            {
                case 1:
                    size = Size.Small;
                    break;
                case 3:
                    size = Size.Medium;
                    break;
                case 5:
                    size = Size.Large;
                    break;
                default:
                    Console.WriteLine("Ongeldige grootte. Standaard ingesteld op klein.");
                    size = Size.Small;
                    break;
            }

            distribution.AddAnimal(new Animal(name, diet, size));
        }


        private void DisplayWagons()
        {
            int i = 1;
            foreach (var wagon in distribution.Train.Wagons)
            {
                Console.WriteLine($"Wagon {i}:");
                foreach (var animal in wagon.Animals)
                {
                    Console.WriteLine($"{animal.Name} ({animal.Diet}, {animal.Size})");
                }
                i++;
            }
        }
    }
}