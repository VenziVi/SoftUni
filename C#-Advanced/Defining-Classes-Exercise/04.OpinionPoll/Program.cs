using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> members = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                members.Add(person);
            }

            members = members.OrderBy(x => x.Name).Where(x => x.Age > 30).ToList();

            foreach (Person person in members)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}

