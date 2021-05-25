using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Dictionary<String, int> foods = new Dictionary<string, int>();
            foods.Add("Bread", 0);
            foods.Add("Cake", 0);
            foods.Add("Pastry", 0);
            foods.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;

                if (sum == 25)
                {
                        foods["Bread"] += 1;
                }
                else if (sum == 50)
                {
                        foods["Cake"] += 1;
                }
                else if (sum == 75)
                {
                        foods["Pastry"] += 1;
                }
                else if (sum == 100)
                {
                        foods["Fruit Pie"] += 1;
                }
                else
                {
                    ingredients.Push(ingredient + 3);
                }
            }

            if (foods["Bread"] > 0 && foods["Cake"] > 0 && foods["Pastry"] > 0 && foods["Fruit Pie"] > 0)
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                List<int> output = new List<int>(liquids.ToList());
                Console.WriteLine($"Liquids left: {string.Join(", ", output)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                List<int> output = new List<int>(ingredients.ToList());
                Console.WriteLine($"Ingredients left: {string.Join(", ", output)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foods.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
