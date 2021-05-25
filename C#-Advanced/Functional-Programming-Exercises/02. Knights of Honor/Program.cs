using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().Select(name => $"Sir {name}").ToArray();
            Action<string[]> printer = name => Console.WriteLine(String.Join(Environment.NewLine, name));
            printer(names);
        }
    }
}
