using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            int shootingCount = 0;
            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            while (true)
            {
                if (shootingCount == barrel && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shootingCount = 0;
                }

                int bullet = 0;
                if (bulletsStack.Count > 0)
                {
                    bullet = bulletsStack.Peek();
                }
                else
                {
                    break;
                }
                
                int currLock = 0;
                if (locksQueue.Count > 0)
                {
                    currLock = locksQueue.Peek();
                }
                else
                {
                    break;
                }

                if (bullet <= currLock)
                {
                    locksQueue.Dequeue();
                    bulletsStack.Pop();
                    Console.WriteLine("Bang!");
                }
                else if (bullet > currLock)
                {
                    bulletsStack.Pop();
                    Console.WriteLine("Ping!");
                }

                shootingCount++;
            }

            if (locksQueue.Count > 0)
            {
                int locksLeft = locksQueue.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
            else
            {
                int bulletsLeft = bulletsStack.Count;
                int moneyEarned = intelligence - ((bullets.Length - bulletsLeft) * bulletPrice);
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
