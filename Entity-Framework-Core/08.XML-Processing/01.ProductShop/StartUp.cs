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

	//04.Import categoryProducts

	 public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Categories_ProductsImportDto[]), new XmlRootAttribute("CategoryProducts"));

            using var reader = new StringReader(inputXml);

            Categories_ProductsImportDto[] dtos = (Categories_ProductsImportDto[])xmlSerializer.Deserialize(reader);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var dto in dtos)
            {
                var category = context
                    .Categories
                    .FirstOrDefault(c => c.Id == dto.CategoryId);

                var product = context
                    .Products
                    .FirstOrDefault(p => p.Id == dto.ProductId);

                if (category == null || product == null)
                {
                    continue;
                }

                CategoryProduct cp = new CategoryProduct
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                };

                categoryProducts.Add(cp);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

	//04.Export products in range

	public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsExportDto[]), new XmlRootAttribute("Products"));

            ProductsExportDto[] productsDto = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000 )
                .OrderBy(p => p.Price)
                .Select(p => new ProductsExportDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(writer, productsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

	//05.Export sold products

	public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(UsersSoldProductDto[]), new XmlRootAttribute("Users"));

            UsersSoldProductDto[] users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UsersSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new SoldProductsDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .ToArray();

            serializer.Serialize(writer, users, xmlns);

            return  sb.ToString().TrimEnd();
        }

	//06.Export categories by products count

	public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesExportDto[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, string.Empty);

            CategoriesExportDto[] categories = context
                .Categories
                .Select(c => new CategoriesExportDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            serializer.Serialize(writer, categories, namespaces);

            return sb.ToString().TrimEnd();
        }

	//07. Export users with products

	public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SellersExportDto), new XmlRootAttribute("Users"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            UsersWithProductsExportDto[] users = context
                .Users
                .Include(u => u.ProductsSold)
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UsersWithProductsExportDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsExportDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(x => new SellerProductsExportDto
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                }).ToArray();


            var result = new SellersExportDto
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };

            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, result, namespaces);
            }

            return stringWriter.GetStringBuilder().ToString().TrimEnd();
        }	
    }
}