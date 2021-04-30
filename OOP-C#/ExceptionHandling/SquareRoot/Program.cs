using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            try
            {
                Number number = new Number(n);
                Console.WriteLine(number.GetSquare());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}
