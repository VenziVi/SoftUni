using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] dataInput = Console.ReadLine().Split();

                try
                {
                    if (input == "Cat")
                    {
                        Cat cat = new Cat(dataInput[0], int.Parse(dataInput[1]), dataInput[2]);
                        animals.Add(cat);
                    }
                    else if (input == "Dog")
                    {
                        Dog dog = new Dog(dataInput[0], int.Parse(dataInput[1]), dataInput[2]);
                        animals.Add(dog);
                    }
                    else if (input == "Frog")
                    {
                        Frog frog = new Frog(dataInput[0], int.Parse(dataInput[1]), dataInput[2]);
                        animals.Add(frog);
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(dataInput[0], int.Parse(dataInput[1]));
                        animals.Add(kitten);
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(dataInput[0], int.Parse(dataInput[1]));
                        animals.Add(tomcat);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
