using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            var ages = int.Parse(Console.ReadLine());
            var person = "";

            if (ages >= 0 && ages <= 2)
            {
                person = "baby";
            }
            else if (ages >= 3 && ages <= 13)
            {
                person = "child";
            }
            else if (ages >= 14 && ages <= 19)
            {
                person = "teenager";
            }
            else if (ages >= 20 && ages <= 65)
            {
                person = "adult";
            }
            else
            {
                person = "elder";
            }

            Console.WriteLine(person);
        }
    }
}
