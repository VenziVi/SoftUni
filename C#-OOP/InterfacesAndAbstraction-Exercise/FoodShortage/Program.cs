using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyerByName = new Dictionary<string, IBuyer>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                if (input.Length == 3)
                {
                    var group = input[2];

                    buyerByName[name] = new Rebel(name, age, group);
                }
                else
                {
                    var id = input[2];
                    var birthDate = input[3];

                    buyerByName[name] = new Citizen(name, age, id, birthDate);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (buyerByName.ContainsKey(input))
                {
                    buyerByName[input].BuyFood();
                }

            }

            var totalFood = buyerByName.Values.Sum(f => f.Food);

            Console.WriteLine(totalFood);
        }
    }
}
