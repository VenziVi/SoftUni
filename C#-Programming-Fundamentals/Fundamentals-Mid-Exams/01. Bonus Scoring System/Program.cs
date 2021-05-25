using System;

namespace _1._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int currentAttendance = 0;

            for (int i = 1; i <= students; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                double totalBonus = (1.0 * attendance / lectures) * (5 + bonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    currentAttendance = attendance;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {currentAttendance} lectures.");
        }
    }
}
