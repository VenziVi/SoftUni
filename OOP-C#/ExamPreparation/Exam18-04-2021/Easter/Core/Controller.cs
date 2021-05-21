using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(Utilities.Messages.OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);
            return string.Format(Utilities.Messages.OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(Utilities.Messages.OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
          
            IEgg egg = eggs.FindByName(eggName);

            List<IBunny> currBuunies = bunnies.Models.ToList();
            //currBuunies = (List<IBunny>)currBuunies.Where(b => b.Energy >= 50 );

            IBunny currbunny = null;
            foreach (var bunny in currBuunies.OrderByDescending(b => b.Energy))
            {
                if (currBuunies.Count == 0)
                {
                    throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.BunniesNotReady);
                }

                IWorkshop work = new Workshop();
                if (bunny.Energy >= 50)
                {
                    currbunny = bunny;
                    //IWorkshop work = new Workshop();
                    work.Color(egg, currbunny);

                    if (currbunny.Energy == 0)
                    {
                        bunnies.Remove(currbunny);
                    }
                }

            }

            if (egg.IsDone())
            {
                return string.Format(Utilities.Messages.OutputMessages.EggIsDone, eggName);
            }
           
            return string.Format(Utilities.Messages.OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            List<IEgg> coloredEggs = new List<IEgg>();
            foreach (var egg in eggs.Models)
            {
                if (egg.IsDone())
                {
                    coloredEggs.Add(egg);
                }
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");
            List<IBunny> currBunnies = bunnies.Models.ToList();

            foreach (var bunny in currBunnies)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");

                int dyesLeft = 0;

                foreach (var dye in bunny.Dyes)
                {
                    if (dye.IsFinished() == false)
                    {
                        dyesLeft++;
                    }
                }

                sb.AppendLine($"Dyes: {dyesLeft} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
