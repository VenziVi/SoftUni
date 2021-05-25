using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }


        public IReadOnlyCollection<IDecoration> Models => models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decor = models.FirstOrDefault(d => d.GetType().Name == type);

            return decor;
        }

        public bool Remove(IDecoration model)
        {
            if (!models.Contains(model))
            {
                return false;
            }

            models.Remove(model);

            return true;
        }
    }
}
