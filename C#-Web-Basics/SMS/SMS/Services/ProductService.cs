using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data;
using SMS.Models;
using SMS.Models.HomeModels;
using SMS.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly SMSDbContext context;

        public ProductService(SMSDbContext _context)
        {
            context = _context;
        }

        

        public (bool isCreated, List<ErrorViewModel> Errors) CreateProduct(CreateViewModel model)
        {
            bool isCreated = true;
            var errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.Name) ||
                model.Name.Length < 4 ||
                model.Name.Length > 20)
            {
                isCreated = false;
                errors.Add(new ErrorViewModel("Product name is required and must be between 4 and 20 characters!"));
            }

            if (model.Price < 0.05M ||
                model.Price > 1000M)
            {
                isCreated |= false;
                errors.Add(new ErrorViewModel("Product price must be between 0.05 and 1000!"));
            }

            if (!isCreated)
            {
                return (isCreated, errors);
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };

            try
            {
                context.Add(product);
                context.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(new ErrorViewModel("Something went wrong!"));
            }

            return (isCreated, errors);
        }
    }
}
