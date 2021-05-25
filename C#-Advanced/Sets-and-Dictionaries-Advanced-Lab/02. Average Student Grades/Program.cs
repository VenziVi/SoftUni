using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string student = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<decimal>());
                }

                students[student].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");

                for (int i = 0; i < student.Value.Count; i++)
                {
                    Console.Write($"{student.Value[i]:f2} ");
                }

                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
