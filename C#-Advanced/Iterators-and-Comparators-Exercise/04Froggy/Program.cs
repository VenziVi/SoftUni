using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Lake lake = new Lake(input);


            Console.WriteLine(string.Join(", ", lake));
            
        }
    }
}
