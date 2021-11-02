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

            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.Address.Town)
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToArray();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
                employee.Address = null;
            }

            var addresses = context.Addresses
                .Include(a => a.Town)
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();



            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            var town = context.Towns.SingleOrDefault(t => t.Name == "Seattle");

            int townAddressCount = town.Addresses.Count();

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{townAddressCount} addresses in Seattle were deleted";
        }
    }
}
