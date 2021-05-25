using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firsLoot = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondLoot = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int lootedSum = 0;

            while (firsLoot.Count > 0 && secondLoot.Count > 0)
            {
                int firstItem = firsLoot.Peek();
                int secondItem = secondLoot.Peek();
                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    lootedSum += sum;
                    firsLoot.Dequeue();
                    secondLoot.Pop();
                }
                else
                {
                    secondLoot.Pop();
                    firsLoot.Enqueue(secondItem);
                }
            }

            if (firsLoot.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondLoot.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (lootedSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootedSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootedSum}");
            }
        }
    }
}
