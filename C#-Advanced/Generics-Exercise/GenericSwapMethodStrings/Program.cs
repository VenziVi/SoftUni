using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            int[] splited = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = splited[0];
            int secondIndex = splited[1];

            box.Swap(list, firstIndex, secondIndex);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
