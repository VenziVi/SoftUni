using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var grup = int.Parse(Console.ReadLine());
            var type = Console.ReadLine();
            var dayOfWeek = Console.ReadLine();
            double price = 0;

            if (type == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = grup * 8.45;
                }
                     else if (dayOfWeek == "Saturday")
                {
                    price = grup * 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = grup * 10.46;
                }
                if (grup >= 30)
                {
                    price = price - price * 0.15;
                }
            }
            if (type == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 10.9;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.6;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }
                if (grup >= 100)
                {
                    price = price * (grup - 10);
                }
                else
                {
                    price = price * grup;
                }
            }
            if (type == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = grup * 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = grup * 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = grup * 22.5;
                }
                if (grup >= 10 && grup <= 20)
                {
                    price = price - price * 0.05;
                }
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
