using SoftUni.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(IncreaseSalaries(context));
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] departments = {"Engineering", "Tool Design", "Marketing", "Information Services"};

            var employeesForIncreaseSalaries = context
                .Employees
                .Where(x => departments.Contains(x.Department.Name))
                .ToArray();

            foreach (var emp in employeesForIncreaseSalaries)
            {
                emp.Salary *= 1.12M;
            }

            context.SaveChanges();

            foreach (var emp in employeesForIncreaseSalaries.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
