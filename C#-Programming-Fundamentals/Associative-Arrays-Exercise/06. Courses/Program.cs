using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] info = input.Split(" : ");
                string coursName = info[0];
                string student = info[1];

                if (!courses.ContainsKey(coursName))
                {
                    courses.Add(coursName, new List<string> {student});
                }
                else
                {
                    courses[coursName].Add(student);
                }

                input = Console.ReadLine();
            }

            foreach (var cours in courses.OrderByDescending(x => x.Value.Count))
            {
                int studentsInCours = cours.Value.Count;
                Console.WriteLine($"{cours.Key}: {studentsInCours}");

                foreach (var item in cours.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
