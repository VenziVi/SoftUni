namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    public class PersonCollection : IPersonCollection
    {
        private List<Person> peopleList;
        private Dictionary<string, Person> personByEmail;
        private Dictionary<string, SortedSet<Person>> personByDomain;
        private Dictionary<string, SortedSet<Person>> personsByNameAndTown;
        private SortedDictionary<int, SortedSet<Person>> personByAge;
        private Dictionary<string,  SortedDictionary<int, SortedSet<Person>>> personsByTownAndAge;

        public PersonCollection()
        {
            peopleList = new List<Person>();
            personByEmail = new Dictionary<string, Person>();
            personByDomain = new Dictionary<string, SortedSet<Person>>();
            personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
            personByAge = new SortedDictionary<int, SortedSet<Person>>();
            personsByTownAndAge = new Dictionary<string, SortedDictionary<int, SortedSet<Person>>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
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

            var domain = email.Split('@')[1];

            if (!this.personByDomain.ContainsKey(domain))
            {
                this.personByDomain.Add(domain, new SortedSet<Person> { newPerson });
            }
            this.personByDomain[domain].Add(newPerson);

            if (!this.personsByNameAndTown.ContainsKey(name + town))
            {
                this.personsByNameAndTown.Add(name + town, new SortedSet<Person> { newPerson });
            }
            this.personsByNameAndTown[name + town].Add(newPerson);

            if (!this.personByAge.ContainsKey(age))
            {
                this.personByAge.Add(age, new SortedSet<Person> { newPerson });
            }
            this.personByAge[age].Add(newPerson);

            if (!this.personsByTownAndAge.ContainsKey(town))
            {
                this.personsByTownAndAge.Add(town, new SortedDictionary<int, SortedSet<Person>>());
            }
            if (!this.personsByTownAndAge[town].ContainsKey(age))
            {
                this.personsByTownAndAge[town].Add(age, new SortedSet<Person>());
            }
            this.personsByTownAndAge[town][age].Add(newPerson);

            this.personByEmail.Add(email, newPerson);
            return true;
        }

        public int Count { get { return this.personByEmail.Count; } }

        public Person FindPerson(string email)
        {
            Person person = null;
            var personExist = this.personByEmail.TryGetValue(email, out person );
            return person;
        }

        public bool DeletePerson(string email)
        {
            if (this.personByEmail.ContainsKey(email))
            {
                var person = personByEmail[email];
                var currNameAndTown = person.Name + person.Town;
                var town = person.Town;
                var currAge = person.Age;

                this.personByEmail.Remove(email);
                this.personByDomain.Remove(email.Split('@')[1]);
                this.personsByNameAndTown.Remove(currNameAndTown);
                this.personByAge.Remove(currAge);
                this.personsByTownAndAge.Remove(town);
                return true;
            }
            
            return false;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            if (!this.personByDomain.ContainsKey(emailDomain))
            {
                //return default;
                yield break;
            }
            var persons = this.personByDomain[emailDomain];
            foreach (var item in persons)
            {
                yield return item;
            }
            //return persons;
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            if (!this.personsByNameAndTown.ContainsKey(name + town))
            {
                return new List<Person>();
            }
            var persons = this.personsByNameAndTown[name + town];

            return persons;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var currPersons = this.personByAge
                .Where(kvp => kvp.Key >= startAge && kvp.Key <= endAge);
            //var result = new List<Person>();

            foreach (var person in currPersons)
            {
                foreach (var item in person.Value)
                {
                    yield return item;
                }
            }

            //return result;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            //var result = new List<Person>();

            if (!this.personsByTownAndAge.ContainsKey(town))
            {
                yield break;
            }

            var personsByTown = personsByTownAndAge[town]
                .Where(kvp => kvp.Key >= startAge && kvp.Key <= endAge);

            foreach (var persons in personsByTown)
            {
                foreach (var item in persons.Value)
                {
                    yield return item;
                }
            }
        }
    }
}
