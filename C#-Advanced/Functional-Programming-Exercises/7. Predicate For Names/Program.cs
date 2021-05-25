using System;
using System.Collections.Generic;

namespace _7._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<int, string[], List<string>> namesToPrint = (length, names) =>
            {
                List<string> newNames = new List<string>();
                foreach (var item in names)
                {
                    if (item.Length <= length)
                    {
                        newNames.Add(item);
                    }
                }

                return newNames;
            };
          
            Action<List<string>> print = 
                name => Console.WriteLine(string.Join(Environment.NewLine, name));
            print(namesToPrint(n, names));
        }
    }
}
