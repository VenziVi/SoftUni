using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < personsInput.Length; i++)
            {
                string[] currPerson = personsInput[i].Split('=');
                string name = currPerson[0];
                decimal money = decimal.Parse(currPerson[1]);
                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] currProduct = productsInput[i].Split('=');
                string name = currProduct[0];
                decimal cost = decimal.Parse(currProduct[1]);
                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] currCommand = command.Split();
                string name = currCommand[0];
                string currproduct = currCommand[1];

                var person = persons.Single(p => p.Name == name);
                var product = products.Single(p => p.Name == currproduct);

                person.AddProduct(person, product);

                command = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                if (person.products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.products.Select(p => p.Name))}");
                }
            }
        }
    }
}
