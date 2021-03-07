using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            //task
            //thread
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int valueNeeded = int.Parse(Console.ReadLine());
            int taskSum = 0;

            while (tasks.Count > 0 || threads.Count > 0)
            {
                int task = tasks.Pop();
                int thread = threads.Peek();
                if (task == valueNeeded)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    break;
                }
                if (thread >= task)
                {
                    taskSum += task;
                    threads.Dequeue();
                }
                else
                {
                    tasks.Push(task);
                    threads.Dequeue();
                }
            }

            List<int> output = new List<int>(threads.ToList());           
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
