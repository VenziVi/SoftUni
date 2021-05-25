using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] cmdArgs = line.Split();
                Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                persons.Add(person);
                
                line = Console.ReadLine();
            }
            persons = persons.OrderBy(x => x.Age).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, persons));
        }

        class Person
        {
            public Person(string name, string iD, int age)
            {
                Name = name;
                Id = iD;
                Age = age;
            }

            public string Name { get; set; }

            public string Id { get; set; }

            public int Age { get; set; }

            public override string ToString()
            {
                return ($"{Name} with ID: {Id} is {Age} years old.").ToString().TrimEnd();
            }
        }
    }
}
