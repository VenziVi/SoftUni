namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dictionary<string, Dog>> ownerWithDogs;
        private Dictionary<string, Dog> dogs;

        public DogVet()
        {
            this.ownerWithDogs = new Dictionary<string, Dictionary<string, Dog>>();
            this.dogs = new Dictionary<string, Dog>();
        }

        public int Size { get { return this.dogs.Count; } }

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.dogs.ContainsKey(dog.Id) ||
                this.ownerWithDogs.ContainsKey(owner.Id) && 
                this.ownerWithDogs[owner.Id].ContainsKey(dog.Name))
                throw new ArgumentException();

            this.dogs.Add(dog.Id, dog);
            dog.Owner = owner;

            if (!this.ownerWithDogs.ContainsKey(owner.Id))
                this.ownerWithDogs[owner.Id] = new Dictionary<string, Dog>();

            this.ownerWithDogs[owner.Id].Add(dog.Name, dog);
        }

        public bool Contains(Dog dog)
        {
            return this.dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownerWithDogs.ContainsKey(ownerId) ||
                !this.ownerWithDogs[ownerId].ContainsKey(name))
                throw new ArgumentException();

            return this.ownerWithDogs[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownerWithDogs.ContainsKey(ownerId) ||
                !this.ownerWithDogs[ownerId].ContainsKey(name))
                throw new ArgumentException();

            var dog = this.ownerWithDogs[ownerId][name];
            this.ownerWithDogs[ownerId].Remove(dog.Name);
            this.dogs.Remove(dog.Id);

            return dog;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.ownerWithDogs.ContainsKey(ownerId))
                throw new ArgumentException();

            return this.ownerWithDogs[ownerId].Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var dogs = this.dogs
                .Values
                .Where(d => d.Breed == breed);

            if (dogs.Count() == 0)
                throw new ArgumentException();

            return dogs;
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownerWithDogs.ContainsKey(ownerId) ||
                !this.ownerWithDogs[ownerId].ContainsKey(name))
                throw new ArgumentException();

            this.ownerWithDogs[ownerId][name].Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownerWithDogs.ContainsKey(ownerId) ||
                !this.ownerWithDogs[ownerId].ContainsKey(oldName))
                throw new ArgumentException();

            var dog = this.ownerWithDogs[ownerId][oldName];
            dog.Name = newName;
            this.ownerWithDogs[ownerId].Remove(oldName);
            this.ownerWithDogs[ownerId].Add(dog.Name, dog);
            
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var dogs = this.dogs.Values.Where(d => d.Age == age).ToList();
            if (dogs.Count == 0)
                throw new ArgumentException();
            return dogs;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            return this.dogs.Values.Where(d => d.Age >= lo && d.Age <= hi);
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return this.dogs.Values.OrderBy(d => d.Age).ThenBy(d => d.Name).ThenBy(d => d.Owner.Name);
        }
    }
}