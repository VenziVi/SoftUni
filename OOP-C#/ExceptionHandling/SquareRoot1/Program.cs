using System;

namespace SquareRoot1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 0)
                {
                    throw new ArgumentException("Invalid Number!");
                }
                if (num == 0)
                {
                    throw new ArgumentException("Number cannot be zero!");
                }

                Console.WriteLine(num * num);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine(fEx.GetType().Name);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
