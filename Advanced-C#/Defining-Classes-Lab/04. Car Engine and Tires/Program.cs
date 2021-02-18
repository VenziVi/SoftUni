using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tyres = new Tire[4]
            {
                new Tire(2012, 2.2),
                new Tire(2012, 2.2),
                new Tire(2012, 2.5),
                new Tire(2012, 2.5)
            };

            Engine v12 = new Engine(225, 3.0);

            Car lambo = new Car("lambo", "devil", 2020, 70, 25.0, v12, tyres);
        }
    }
}
