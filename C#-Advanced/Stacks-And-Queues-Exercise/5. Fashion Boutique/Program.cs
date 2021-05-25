using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> box = new Stack<int>(clothesInBox);
            int rackCount = 1;
            int clothesValue = 0;

            while (box.Count > 0)
            {
                clothesValue += box.Peek();

                if (clothesValue <= rackCapacity)
                {
                    box.Pop();
                }
                else
                {
                    clothesValue = 0;
                    rackCount++;
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
