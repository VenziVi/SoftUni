using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExamReatake
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int currTask = tasks.Peek();
                int curThread = threads.Peek();

                if (currTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {curThread} killed task {taskToKill}");
                    Console.WriteLine(string.Join(" ", threads));
                    break;
                }

                if (curThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else 
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
