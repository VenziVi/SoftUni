using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        //private ICar car;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }


        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; } = false;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Car cannot be null.");
            }

            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
