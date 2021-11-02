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

            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .Include(x => x.Manager)
                .Include(x => x.Employees)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.Manager.FirstName} {department.Manager.LastName}");

                var employees = department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

                foreach (var emp in employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
