using System;

namespace Methods___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            SmallestOfTreeNumber(n1, n2, n3);
        }

        private static void SmallestOfTreeNumber(int n1, int n2, int n3)
        {
            int result = 0;
            if (n1 <= n2 && n1 <= n3)
            {
                result = n1;
            }
            else if (n2 <= n1 && n2 <= n3)
            {
                result = n2;
            }
            else if (n3 <= n1 && n3 <= n2)
            {
                result = n3;
            }
            Console.WriteLine(result);
        }
    }
}
