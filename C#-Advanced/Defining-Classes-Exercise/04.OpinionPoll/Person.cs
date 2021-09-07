using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(int age) 
            : this("No name", age)
        {
        }

        public Person() 
            : this("No name", 1)
        {
        }
    }
}