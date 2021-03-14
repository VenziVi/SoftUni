using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            PetsList = new List<Pet>();
        }

        private List<Pet> PetsList;
        public int Capacity { get; set; }
        public int Count { get { return PetsList.Count; } }
        public void Add(Pet pet)
        {
            if (PetsList.Count < Capacity)
            {
                PetsList.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = PetsList.FirstOrDefault(p => p.Name == name);
            if (pet == null)
            {
                return false;
            }
            PetsList.Remove(pet);
            return true;
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = PetsList.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            return pet;
        }
        public Pet GetOldestPet()
        {
            return PetsList.OrderByDescending(p => p.Age).FirstOrDefault();
        }
        public string GetStatistics()
        {
            StringBuilder finalString = new StringBuilder();
            finalString.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in PetsList)
            {
                finalString.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return finalString.ToString();
        }
    }
}