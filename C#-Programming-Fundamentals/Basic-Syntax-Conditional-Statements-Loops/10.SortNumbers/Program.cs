using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double result1 = 0;
            double result2 = 0;
            double result3 = 0;

            if (a > b && a> c)
            {
                result1 = a;
                if (b > c)
                { 
                    result2 = b;
                    result3 = c;
                }
                else
                {  
                    result2 = c;
                    result3 = b;
                }
            }
            else if (b > a && b > c)
            {
                result1 = b;
                if (a > c)
                { 
                    result2 = a;
                    result3 = c;
                }
                else
                {  
                    result2 = c;
                    result3 = a;
                }
            }
            else if (c > a && c > b)
            {
                result1 = c;
                if (a > b)
                {
                    result2 = a;
                    result3 = b;
                }
                else
                {
                    result2 = b;
                    result3 = a;
                }
            }
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }
    }
}
