using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using Newtonsoft.Json.Serialization;
using ProductShop.InputDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var inputUsers = File.ReadAllText("../../../Datasets/users.json");
            //var inputPeoducts = File.ReadAllText("../../../Datasets/products.json");
            //var inputCategories = File.ReadAllText("../../../Datasets/categories.json");
            //var inputCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, inputUsers));
            //Console.WriteLine(ImportProducts(context, inputPeoducts)); 
            //Console.WriteLine(ImportCategories(context, inputCategories));
            //Console.WriteLine(ImportCategoryProducts(context, inputCategoriesProducts));
            //Console.WriteLine(GetUsersWithProducts(context));
        }
	
	//01.import users

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            var mapperConfiguration = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfiguration);

            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

	//02.import products
	
	public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfig);

            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

	//03.import categories

	public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesInputDto> categories = JsonConvert.DeserializeObject<IEnumerable<CategoriesInputDto>>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name));

            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfig);

            var meppedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(meppedCategories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

	//04.import categories and products

	public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesProductsInputDto> categoriesProducts = JsonConvert
                .DeserializeObject<IEnumerable<CategoriesProductsInputDto>>(inputJson);

            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfig);

            IEnumerable<CategoryProduct> mappedCategoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProducts);

            context.CategoryProducts.AddRange(mappedCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }
    }
}