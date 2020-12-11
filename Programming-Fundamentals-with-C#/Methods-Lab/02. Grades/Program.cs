using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            corespondingGrade(grade);
        }

        static void corespondingGrade(double number)
        {
            string grade = string.Empty;

            if (number >= 2 && number <= 2.99)
            {
                grade = "Fail";
            }
            else if (number >= 3 && number <= 3.49)
            {
                grade = "Poor";
            }
            else if (number >= 3.50 && number <= 4.49)
            {
                grade = "Good";
            }
            else if (number >= 4.50 && number <= 5.49)
            {
                grade = "Very good";
            }
            else if (number >= 5.50 && number <= 6.00)
            {
                grade = "Excellent";
            }

            Console.WriteLine(grade);
        }        
    }
}
