using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();
            
            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                int currentPetrolAmount = 0;
                bool isSuccessful = true;
                for (int j = 0; j < n; j++)
                {
                    string pumpInfo = pumps.Dequeue();
                    int[] pump = pumpInfo.Split().Select(int.Parse).ToArray();
                    pumps.Enqueue(pumpInfo);
                    currentPetrolAmount += pump[0];
                    currentPetrolAmount -= pump[1];

                    if (currentPetrolAmount < 0)
                    {
                        isSuccessful = false;
                    }
                }

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }

                string temdDate = pumps.Dequeue();
                pumps.Enqueue(temdDate);
                GC.Collect();
            }


        }
    }
}
