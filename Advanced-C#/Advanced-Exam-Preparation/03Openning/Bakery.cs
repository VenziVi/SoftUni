using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }


        public void Add(Employee employee)
        {
            data.Add(employee);
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            if (employee == null)
            {
                return false;
            }

            data.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            return employee;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                report.AppendLine($"{employee.Name}, {employee.Age} ({employee.Country})");
            }
            return report.ToString();
        }
    }
}
