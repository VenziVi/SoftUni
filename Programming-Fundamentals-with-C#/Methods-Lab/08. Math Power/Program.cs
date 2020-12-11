using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = RaisedNumber(number, power);

            Console.WriteLine(result);
        }

        private static double RaisedNumber(double number, int power)
        {
            double result = (double)Math.Pow(number, power);
            return result;
        }
    }
}
