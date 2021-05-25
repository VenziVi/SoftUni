using System;

namespace Facade
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                     .WithType("BMW")
                     .WithColor("Black")
                     .WithNumberOfDoors(3)
                .Built
                     .WithCity("Bavaria")
                     .WithAddress("blvd.\"st.Jones 254\"")
                .Build();

            Console.WriteLine(car);
        }
    }
}
