using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligence = int.Parse(Console.ReadLine());

            int currBarrel = barrelSize;
            int bulletsShot = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {

                int currBullet = bullets.Pop();
                bulletsShot++;
                currBarrel--;
                int currLock = locks.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currBarrel = barrelSize;
                }
            }

            int bulletsPrice = bulletsShot * bulletPrice;

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - bulletsPrice}");
            }
        }
    }
}
