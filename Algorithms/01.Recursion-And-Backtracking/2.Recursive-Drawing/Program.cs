using System;

namespace _2.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            DrawRecursivly(n);
        }

        private static void DrawRecursivly(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new String('*', n));
            DrawRecursivly(n - 1);
            Console.WriteLine(new String('#', n));
        }
    }
}
