using SMS.Contracts;
using SMS.Data;
using SMS.Models.HomeModels;
using SMS.Models;
using System.Linq;
using System.Collections.Generic;

namespace SMS.Services
{
    public class HomeService : IHomeService
    {
        private readonly SMSDbContext context;

        public HomeService(SMSDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<AllProductsViewModel> GetProducts()
        {
            var products = context.Set<Product>()
                .Select(p => new AllProductsViewModel()
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                }).ToList();

            return products;
        }
    }
}
