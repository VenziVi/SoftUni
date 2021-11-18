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
            Console.WriteLine(GetUsersWithProducts(context));
        }

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
    }
}