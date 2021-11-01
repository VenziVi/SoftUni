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

            Console.WriteLine(GetEmployeesInPeriod(context));
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




        //public static string GetEmployeesInPeriod1(SoftUniContext context)
        //{

        //    var employees = context.Employees
        //        .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.LastName,
        //            ManagerFirstName = e.Manager.FirstName,
        //            ManagerLastName = e.Manager.LastName,
        //            Projects = e.EmployeesProjects.Select
        //            (
        //                ep => new
        //                {
        //                    ep.Project.Name,

        //                    StartDate =
        //                        ep.Project.StartDate.
        //                            ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),

        //                    EndDate =
        //                        ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value
        //                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
        //                }
        //            )
        //        })
        //        .Take(10)
        //        .ToArray();

        //    StringBuilder sb = new StringBuilder();

        //    foreach (var empoyee in employees)
        //    {
        //        sb.AppendLine($"{empoyee.FirstName} {empoyee.LastName} - Manager: {empoyee.ManagerFirstName} {empoyee.ManagerLastName}");

        //        foreach (var project in empoyee.Projects)
        //        {
        //            sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
        //        }
        //    }


        //    return sb.ToString().TrimEnd();

        //}

    }
}
