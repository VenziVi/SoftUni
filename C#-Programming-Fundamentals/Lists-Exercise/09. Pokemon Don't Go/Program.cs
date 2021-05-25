using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distance = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int sum = 0;
            int index = int.Parse(Console.ReadLine());

            while (true)
            {
                if (index < 0)
                {
                    int value = distance[distance.Count - 1];
                    int distanceValue = distance[0];
                    sum += distance[0];
                    distance[0] = value;
                    ChangeDistance(distanceValue, distance);
                }
                else if (index > distance.Count - 1)
                {
                    int value = distance[0];
                    int distanceValue = distance[distance.Count - 1];
                    sum += distance[distance.Count - 1];
                    distance.RemoveAt(distance.Count - 1);
                    distance.Add(value);
                    ChangeDistance(distanceValue, distance);
                }
                else
                {
                    int distanceValue = distance[index];
                    sum += distanceValue;
                    distance.RemoveAt(index);
                    ChangeDistance(distanceValue, distance);

                }
                if (distance.Count == 0)
                {
                    break;
                }

                index = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }

        private static List<int> ChangeDistance(int distanceValue, List<int> distance)
        {
            for (int i = 0; i < distance.Count; i++)
            {
                if (distance[i] > distanceValue)
                {
                    distance[i] -= distanceValue;
                }
                else
                {
                    distance[i] += distanceValue;
                }
            }
            return distance;
        }
    }
}
