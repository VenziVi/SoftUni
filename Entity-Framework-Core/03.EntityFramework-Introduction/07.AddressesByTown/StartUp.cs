using SoftUni.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetAddressesByTown(context));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        { 
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(p =>
                    p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    mangerFirstName = e.Manager.FirstName,
                    managerLastName = e.Manager.LastName,
                    projects = e.EmployeesProjects.Select(pe => new
                    {
                        pe.Project.Name,
                        start = pe.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        end = pe.Project.EndDate == null
                            ? "not finished"
                            : pe.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                    })
                })
                .Take(10)
                .ToArray();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.mangerFirstName} {emp.managerLastName}");

                foreach (var project in emp.projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.start} - {project.end}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .Select(a => new
                {
                    address = a.AddressText,
                    town = a.Town.Name,
                    employeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.employeeCount)
                .ThenBy(a => a.town)
                .ThenBy(a => a.address)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.address}, {address.town} - {address.employeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
