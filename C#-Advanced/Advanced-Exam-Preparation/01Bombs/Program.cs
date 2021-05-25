using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);

            while (effects.Count > 0 && casings.Count > 0 && !AreBombsEnought(bombs["Cherry Bombs"], bombs["Datura Bombs"], bombs["Smoke Decoy Bombs"]))
            {
                int effect = effects.Peek();
                int casing = casings.Pop();
                int sum = effect + casing;

                if (sum == 40)
                {
                    bombs["Datura Bombs"] += 1;
                    effects.Dequeue();
                }
                else if (sum == 60)
                {
                    bombs["Cherry Bombs"] += 1;
                    effects.Dequeue();
                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"] += 1;
                    effects.Dequeue();
                }
                else
                {
                    casing -= 5;
                    casings.Push(casing);
                }
            }

            if (AreBombsEnought(bombs["Cherry Bombs"], bombs["Datura Bombs"], bombs["Smoke Decoy Bombs"]))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count > 0)
            {
                List<int> output = effects.ToList();
                Console.WriteLine($"Bomb Effects: {string.Join(", ", output)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Count > 0)
            {
                List<int> output = casings.ToList();
                Console.WriteLine($"Bomb Casings: {string.Join(", ", output)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }

        public static bool AreBombsEnought(int chery, int datura, int smoke)
        {
            if (chery >= 3 && datura >= 3 && smoke >= 3)
            {
                return true;
            }

            return false;
        }
    }
}
