using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishs;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            decorations = new List<IDecoration>();
            fishs = new List<IFish>();
        }


        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
        {
            get
            {
                int sum = 0;
                foreach (var decor in decorations)
                {
                    sum += decor.Comfort;
                }
                return sum;
            }
        }

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fishs.AsReadOnly();



        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishs.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.NotEnoughCapacity);
            }

            fishs.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishs)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (fishs.Count == 0)
            {
                sb.AppendLine($"Fish: none");

            }
            else if (fishs.Count == 1)
            {
                foreach (var fish in fishs)
                {
                    sb.AppendLine($"Fish: {fish.Name}");
                }

            }
            else
            {
                for (int i = 0; i < fishs.Count; i++)
                {
                    IFish fish = fishs[i];

                    if (i == fishs.Count - 1)
                    {
                        sb.AppendLine($"{fish.Name}");
                    }
                    else if (i >= 0 && i < fishs.Count - 1)
                    {
                        sb.Append($"Fish: {fish.Name}, ");
                    }

                }
            }

            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (fishs.Count == 0)
            {
                return false;
            }

            if (!fishs.Contains(fish))
            {
                return false;
            }
            //Check if error

            fishs.Remove(fish);
            return true;
        }
    }
}
