namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollectionSlow : IPersonCollection
    {
        private List<Person> peopleList;

        public PersonCollectionSlow()
        {
            peopleList = new List<Person>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (peopleList.Any(p => p.Email == email))
            {
                return false;
            }

            var newPerson = new Person()
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town
            };

            this.peopleList.Add(newPerson);
            return true;
        }

        public int Count { get { return this.peopleList.Count; } }

        public Person FindPerson(string email)
        {
            var person = this.peopleList.FirstOrDefault(p => p.Email == email);
            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);

            if (person == null)
            {
                return false;
            }

            this.peopleList.Remove(person);
            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            var currPersons = new List<Person>();

            foreach (var person in this.peopleList)
            {
                if (person.Email.Split('@')[1] == emailDomain)
                {
                    currPersons.Add(person);
                }
            }

            return currPersons.OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var persons = this.peopleList.Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);

            return persons;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.peopleList.Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            return this.peopleList.Where(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }
    }
}
