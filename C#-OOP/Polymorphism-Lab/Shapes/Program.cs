using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Shape circle = new Circle(4.1);
                Console.WriteLine(circle.CalculateArea());
                Console.WriteLine(circle.CalculatePerimeter());
                Console.WriteLine(circle.Draw());

                Shape react = new Rectangle(3.2, 4);
                Console.WriteLine(react.CalculateArea());
                Console.WriteLine(react.CalculatePerimeter());
                Console.WriteLine(react.Draw());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
