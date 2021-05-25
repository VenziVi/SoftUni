using System;

namespace Login
{
    class Program
    {
        public static object StringHelper { get; private set; }

        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            
            Console.WriteLine(StringHelper.ReverseString("This"));
        }
    }
}
