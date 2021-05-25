using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (Count >= Capacity)
            {
                return $"No seats in the classroom";
            }
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }
            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.FirstOrDefault(x => x.Subject == subject) != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in students.Where(x => x.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
