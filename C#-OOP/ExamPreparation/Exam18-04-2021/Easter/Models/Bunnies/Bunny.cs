using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private readonly List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            dyes = new List<IDye>();

            this.Name = name;
            this.Energy = energy;
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes => dyes.AsReadOnly();

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public abstract void Work();
    }
}
