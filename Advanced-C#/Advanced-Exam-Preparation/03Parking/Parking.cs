using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
     public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Car car)
        {
            if (Capacity > data.Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (car == null)
            {
                return false;
            }

            data.Remove(car);
            return true;
        }

        public Car GetLatestCar()
        {
            Car car = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                output.AppendLine(car.ToString());
            }
            return output.ToString().TrimEnd();  
        }
    }
}
