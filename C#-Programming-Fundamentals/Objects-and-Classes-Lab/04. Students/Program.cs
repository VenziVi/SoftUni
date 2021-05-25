using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string currentStudent = Console.ReadLine();

            while (currentStudent != "end")
            {
                string[] studentInfo = currentStudent
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student();
                student.firstName = studentInfo[0];
                student.lastName = studentInfo[1];
                student.age = studentInfo[2];
                student.homeTown = studentInfo[3];

                students.Add(student);

                currentStudent = Console.ReadLine();
            }

            string cityName = Console.ReadLine();


            List<Student> fiterdStudents = students
                .Where(n => n.homeTown == cityName)
                .ToList();

            foreach (var student in fiterdStudents)
            {
                Console.WriteLine($"{ student.firstName} {student.lastName} is { student.age } years old.");
            }
        }
    }

    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public string homeTown { get; set; }

    }
}
