using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private  IRepository<IDecoration> decorations;
        private  Dictionary<string, IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new Dictionary<string, IAquarium>();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquariumName, aquarium);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decor = null;

            if (decorationType == nameof(Ornament))
            {
                decor = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decor = new Plant();
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decor);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums[aquariumName];

            if (aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                if (fishType == "SaltwaterFish")
                {
                    return Utilities.Messages.OutputMessages.UnsuitableWater;
                }
            }

            if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                if (fishType == "FreshwaterFish")
                {
                    return Utilities.Messages.OutputMessages.UnsuitableWater;
                }
            }

            aquarium.AddFish(fish);
            return string.Format(Utilities.Messages.OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aqua = aquariums[aquariumName];

            decimal sum = 0;

            foreach (var fish in aqua.Fish)
            {
                sum += fish.Price;
            }

            foreach (var decor in aqua.Decorations)
            {
                sum += decor.Price;
            }

            return string.Format(Utilities.Messages.OutputMessages.AquariumValue, aquariumName, $"{sum:f2}");
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aqua = aquariums[aquariumName];

            int count = aqua.Fish.Count;
            aqua.Feed();

            return string.Format(Utilities.Messages.OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decor = decorations.FindByType(decorationType);

            if (decor == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = aquariums[aquariumName];

            //If Error Check

            aquarium.AddDecoration(decor);
            decorations.Remove(decor);

            return string.Format(Utilities.Messages.OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aqua in aquariums)
            {
                sb.AppendLine(aqua.Value.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
