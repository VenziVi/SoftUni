using System;
using System.Linq;

namespace _2._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int counter = 0;
            string input = Console.ReadLine();

            while (input?.ToLower() != "end")
            {
                int index = int.Parse(input);

                if (index <= targets.Length - 1 && index >= 0 && targets[index] != -1)
                {
                    int value = targets[index];
                    targets[index] = -1;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] > value && targets[i] != -1)
                        {
                            targets[i] -= value;
                        }
                        else if (targets[i] <= value && targets[i] != -1)
                        {
                            targets[i] += value;
                        }
                    }
                    counter++;          
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", targets)}");
        }
    }
}
