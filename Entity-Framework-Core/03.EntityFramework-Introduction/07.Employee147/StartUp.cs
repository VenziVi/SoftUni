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

            Console.WriteLine(GetEmployee147(context));
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var emp147 = context
                .Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    firstName = e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    projects = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name
                    })
                })
                .First(e => e.EmployeeId == 147);
                

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{emp147.firstName} {emp147.LastName} - {emp147.JobTitle}");

            foreach (var project in emp147.projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
