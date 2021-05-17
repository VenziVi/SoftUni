using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public void Add(ICar model) 
            => this.cars.Add(model);

        public IReadOnlyCollection<ICar> GetAll() 
            => this.cars.ToArray();


        public ICar GetByName(string name) 
            => this.cars.FirstOrDefault(c => c.Model == name);

        public bool Remove(ICar model) 
            => this.cars.Remove(model);
    }
}
