using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FacturialCalc(n));
        }

        private static int FacturialCalc(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * FacturialCalc(n - 1);
        }
    }
}
