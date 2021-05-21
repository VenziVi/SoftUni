using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
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

        public int EnergyRequired { get; private set; }

        public void GetColored()
        {
            this.EnergyRequired -= 10;

            if (this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone() => this.EnergyRequired == 0;
    }
}
