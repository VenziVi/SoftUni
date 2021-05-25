using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepositary;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepositary = new CarRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var currDriver = driverRepository.GetByName(driverName);
            var currCar = carRepositary.GetByName(carModel);

            if (currDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (currCar == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            currDriver.AddCar(currCar);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var currRace = raceRepository.GetByName(raceName);
            var currDriver = driverRepository.GetByName(driverName);

            if (currRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (currDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found");
            }

            currRace.AddDriver(currDriver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (carRepositary.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            carRepositary.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
           

            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);

            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var currRace = raceRepository.GetByName(raceName);

            if (currRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (currRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = currRace.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(currRace.Laps)).ToList();

            var first = drivers[0];
            var second = drivers[1];
            var third = drivers[2];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {first.Name} wins {raceName} race.");
            sb.AppendLine($"Driver {second.Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {third.Name} is third in {raceName} race.");

            raceRepository.Remove(currRace);
            return sb.ToString().TrimEnd();
        }
    }
}
