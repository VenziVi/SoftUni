using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var input = File.ReadAllText("Datasets/categories-products.xml");

            //System.Console.WriteLine(GetUsersWithProducts(context));
        }
	
	//01.Import users
	
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersImportDto[]), xmlRoot);

            UsersImportDto[] dtos = null;

            using (StringReader sr = new StringReader(inputXml))
            {
                dtos = (UsersImportDto[])xmlSerializer.Deserialize(sr);
            }

            ICollection<User> users = new HashSet<User>();
            foreach (UsersImportDto dto in dtos)
            {
                User u = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                };

                users.Add(u);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

	//02.Import products
	
	public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]), xmlRoot);

            ProductImportDto[] dtos = null;

            using (StringReader sr = new StringReader(inputXml))
            {
                dtos = (ProductImportDto[])xmlSerializer.Deserialize(sr);
            }

            ICollection<Product> products = new HashSet<Product>();

            foreach (var dto in dtos)
            {
                Product p = new Product
                {
                    Name = dto.Name,
                    Price = decimal.Parse(dto.Price),
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId
                };

                products.Add(p);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

	//03.Import categories

	public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesImportDto[]), new XmlRootAttribute("Categories"));

            using var sr = new StringReader(inputXml);

            CategoriesImportDto[] dtos = (CategoriesImportDto[])xmlSerializer.Deserialize(sr);

            ICollection<Category> categories = new HashSet<Category>();
            foreach (var dto in dtos)
            {
                if (dto.Name == null)
                {
                    continue;
                }

                Category c = new Category
                {
                    Name = dto.Name
                };

                categories.Add(c);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }	
    }
}