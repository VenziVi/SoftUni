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

            Console.WriteLine(DeleteProjectById(context));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context.Projects
                .Include(p => p.EmployeesProjects)
                .SingleOrDefault(p => p.ProjectId == 2);

            if (project != null)
            {
                foreach (var projectType in project.EmployeesProjects)
                {
                    context.EmployeesProjects.Remove(projectType);
                }
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Take(10).ToArray();

            foreach (var prj in projects)
            {
                sb.AppendLine($"{prj.Name}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
