using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> carNumbers = new HashSet<string>();

            while (input != "END")
            {
                string[] splited = input.Split(", ");
                string cmd = splited[0];
                string number = splited[1];

                if (cmd == "IN")
                {
                    carNumbers.Add(number);
                }
                else if (cmd == "OUT")
                {
                    if (carNumbers.Contains(number))
                    {
                        carNumbers.Remove(number);
                    }
                }

                input = Console.ReadLine();
            }

            if (carNumbers.Count > 0)
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
