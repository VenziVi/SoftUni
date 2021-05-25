using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public void Add(IRace model)
            => this.races.Add(model);

        public IReadOnlyCollection<IRace> GetAll()
            => this.races.ToArray();


        public IRace GetByName(string name)
            => this.races.FirstOrDefault(d => d.Name == name);

        public bool Remove(IRace model)
            => this.races.Remove(model);
    }
}
