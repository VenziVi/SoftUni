using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            var element = Console.ReadLine();

            Console.WriteLine(box.CountMethod(list, element));           
        }
    }
}
