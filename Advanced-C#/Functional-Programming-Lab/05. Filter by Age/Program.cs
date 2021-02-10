using System;

namespace _05._Filter_by_Age
{
    class Person 
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person();
                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);
            }

            string filter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> condition = GetAgeCondition(filter, ageFilter);
            Func<Person, string> formater = CurrFormate(format);
            PrintPeople(people, condition, formater);
        }

        private static Func<Person, string> CurrFormate(string format)
        {
            switch (format)
            {
                case "name": return p => $"{p.Name}";
                case "age": return p => $"{p.Age}";
                case "name age": return p => $"{p.Name} - {p.Age}";
                default: return null;
            }
        }

        private static Func<Person, bool> GetAgeCondition(string filter, int ageFilter) 
        {
            switch (filter)
            {
                case "younger": return p => p.Age < ageFilter;
                case "older": return p => p.Age >= ageFilter;

                default:
                    return null;
            }
        }

        private static void PrintPeople(Person[] people, Func<Person, bool> condition, Func<Person, string> formater)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formater(person));
                };
            }
        }
    }  
}
