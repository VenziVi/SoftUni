using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = ArrayCreator.Create(5, "ivan");

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
