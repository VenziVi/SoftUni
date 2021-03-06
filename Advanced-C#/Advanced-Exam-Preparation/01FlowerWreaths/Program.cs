using System;
using System.Collections.Generic;
using System.Linq;

namespace _01FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> roses = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> lilies = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int wreathCount = 0;
            int flolersLeft = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Peek();
                int rose = roses.Pop();
                int sum = rose + lili;

                if (sum == 15)
                {
                    wreathCount++;
                    lilies.Dequeue();
                }
                else if (sum > 15)
                {
                    roses.Push(rose - 2);
                }
                else
                {
                    flolersLeft += sum;
                    lilies.Dequeue();
                }
            }

            if (flolersLeft >= 15)
            {
                wreathCount += flolersLeft / 15;
            }

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}
