using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            double f1 = FactorialN1(n1);
            double f2 = FactorialN2(n2);
            Devision(f1, f2);
        }

        private static void Devision(double f1, double f2)
        {
            double result = f1 / f2;
            Console.WriteLine($"{result:f2}");
        }

        private static double FactorialN2(int n2)
        {
            double factorial = 1;
            for (int i = 1; i <= n2; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }

        private static double FactorialN1(int n1)
        {
            double factorial = 1;
            for (int i = 1; i <= n1; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }
}
