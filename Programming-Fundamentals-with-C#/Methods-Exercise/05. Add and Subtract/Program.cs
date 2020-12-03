using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int sum = SumOfFirstAndSecond(n1, n2);
            int substract = SubstractSum(sum, n3);
            Console.WriteLine(substract);

        }

        private static int SubstractSum(int sum, int n3)
        {
            int substract = sum - n3;
            return substract;
        }

        private static int SumOfFirstAndSecond(int n1, int n2)
        {
            int sum = n1 + n2;
            return sum;
        }
    }
}
