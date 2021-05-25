using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            byte charByte = Convert.ToByte(letter);

            if (charByte >= 65 && charByte <= 90)
            {
                Console.WriteLine("upper -case");
            }
            else if (charByte >= 97 && charByte <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
