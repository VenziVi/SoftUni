using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] line = input.Split("-");

                if (line.Length > 2)
                {
                    string name = line[0];
                    string language = line[1];
                    int points = int.Parse(line[2]);

                    if (!participants.ContainsKey(name))
                    {
                        participants.Add(name, points);
                    }
                    else
                    {
                        if (participants[name] < points)
                        {
                            participants[name] = points;
                        }
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;
                }
                else
                {
                    string name = line[0];

                    if (participants.ContainsKey(name))
                    {
                        participants.Remove(name);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var user in participants.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
