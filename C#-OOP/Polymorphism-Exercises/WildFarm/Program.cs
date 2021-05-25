using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Bird;
using WildFarm.Animals.Mammal;
using WildFarm.Animals.Mammal.Feline;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var animalInput = line.Split();

                Animal animal = CreateAnimal(animalInput);

                var foodInput = Console.ReadLine().Split();

                Food food = CreateFood(foodInput);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodInput)
        {
            Food food = null;
            var type = foodInput[0];
            var quantity = int.Parse(foodInput[1]);

            if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] animalInput)
        {
            Animal animal = null;
            var type = animalInput[0];
            var name = animalInput[1];
            var weight = double.Parse(animalInput[2]);

            if (type == nameof(Owl))
            {
                var wingSize = double.Parse(animalInput[3]);
                animal = new Owl(name, weight, 0, wingSize);
            }
            else if (type == nameof(Hen))
            {
                var wingSize = double.Parse(animalInput[3]);
                animal = new Hen(name, weight, 0, wingSize);
            }
            else if (type == nameof(Dog))
            {
                var region = animalInput[3];
                animal = new Dog(name, weight, 0, region);
            }
            else if (type == nameof(Mouse))
            {
                var region = animalInput[3];
                animal = new Mouse(name, weight, 0, region);
            }
            else if (type == nameof(Cat))
            {
                var region = animalInput[3];
                var breed = animalInput[4];
                animal = new Cat(name, weight, 0, region, breed);
            }
            else if (type == nameof(Tiger))
            {
                var region = animalInput[3];
                var breed = animalInput[4];
                animal = new Tiger(name, weight, 0, region, breed);
            }

            return animal;
        }
    }
}
