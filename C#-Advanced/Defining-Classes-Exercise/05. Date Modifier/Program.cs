using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int days = DateModifier.GetDiference(firstDate, secondDate);

            Console.WriteLine(Math.Abs(days));
        }    
    }
}
