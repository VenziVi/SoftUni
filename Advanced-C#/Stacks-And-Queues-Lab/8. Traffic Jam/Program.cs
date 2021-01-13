using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            var passedCarsCount = 0;
            var input = Console.ReadLine();

            while (input != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else if (input == "green")
                {
                    if (cars.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCarsCount++;
                        }
                    }
                    else
                    {
                        int carsNum = cars.Count;
                        for (int i = 0; i < carsNum; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCarsCount++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}
