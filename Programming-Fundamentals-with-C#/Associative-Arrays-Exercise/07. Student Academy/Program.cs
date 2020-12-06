using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }

            Dictionary<string, double> filtredStudents = new Dictionary<string, double>();

            foreach (var currentStudent in students)
            {
                double avarageGrade = currentStudent.Value.Average();
                if (avarageGrade >= 4.50)
                {
                    filtredStudents.Add(currentStudent.Key, avarageGrade);
                }
            }

            foreach (var student in filtredStudents.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
