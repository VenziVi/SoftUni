using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();

            while (input != "End")
            {
                string[] info = input.Split(" -> ");
                string company = info[0];
                string id = info[1];

                if (!employees.ContainsKey(company))
                {
                    employees.Add(company, new List<string>{id});

                }
                if (!employees[company].Contains(id))
                {
                    employees[company].Add(id);
                }

                input = Console.ReadLine();
            }

            foreach (var item in employees.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {string.Join("",id)}");
                }
            }
        }
    }
}
