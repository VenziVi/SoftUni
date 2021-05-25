using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> sets = new List<int>();
            int set = 0;

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currHat = hats.Peek();
                int currScarf = scarfs.Peek();

                if (currHat > currScarf)
                {
                    set = hats.Pop() + scarfs.Dequeue();
                    sets.Add(set);
                }
                else if (currHat < currScarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    int hatIncrease = hats.Pop();
                    hats.Push(hatIncrease + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
