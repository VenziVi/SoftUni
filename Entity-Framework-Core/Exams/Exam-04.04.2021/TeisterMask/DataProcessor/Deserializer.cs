namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {	
            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projects"));

            using StringReader reader = new StringReader(xmlString);

            ImportProjectsDto[] dtos = (ImportProjectsDto[])serializer.Deserialize(reader);

            var projects = new HashSet<Project>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isOpenDateValid = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedOpenDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? currDueDate = null;

                if (!string.IsNullOrWhiteSpace(dto.DueDate))
                {
                    var isDueDateValid = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDueDate);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currDueDate = parsedDueDate;
                }

                Project p = new Project
                {
                    Name = dto.Name,
                    OpenDate = parsedOpenDate,
                    DueDate = currDueDate,
                };

                var tasks = new HashSet<Task>();

                foreach (var task in dto.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTaskOpenDate);

                    bool isTaskDueDateValid = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTaskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (parsedTaskOpenDate < p.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (p.DueDate.HasValue && parsedTaskDueDate > p.DueDate )
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task
                    {
                        Name = task.Name,
                        OpenDate = parsedTaskOpenDate,
                        DueDate = parsedTaskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType, 
                        LabelType = (LabelType)task.LabelType,
                        //Project = p
                    };

                    tasks.Add(t);
                    
                }

                p.Tasks = tasks;
                projects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, p.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            IEnumerable<ImportUsersDto> users = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);
            var employees = new HashSet<Employee>();

            foreach (var user in users)
            {
                if (!IsValid(user))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee
                {
                    Username = user.Username,
                    Email = user.Email,
                    Phone = user.Phone
                };

                var employeeTasks = new HashSet<EmployeeTask>();

                foreach (var currTask in user.Tasks.Distinct())
                {
                    var uniqueTask = context.Tasks.Find(currTask);

                    if (uniqueTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask et = new EmployeeTask
                    {
                        Employee = e,
                        TaskId = uniqueTask.Id
                    };

                    employeeTasks.Add(et);
                }

                e.EmployeesTasks = employeeTasks;
                employees.Add(e);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}