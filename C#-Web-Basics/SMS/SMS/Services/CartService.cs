using BasicWebServer.Server.Attributes;
using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data;
using SMS.Models;
using SMS.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly SMSDbContext context;

        public CartService(SMSDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<CartProductViewModel> AddProductToCart(string id, string productId)
        {
            var currUser = FindUserById(id);

            Product currProduct = context.Set<Product>().FirstOrDefault(p => p.Id == productId);

            currUser.Cart.Products.Add(currProduct);
            context.SaveChanges();

            return currUser.Cart.Products
                .Select(p => new CartProductViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

        public void BuyProducts(string id)
        {
            var user = FindUserById(id);

            user.Cart.Products.Clear();

            context.SaveChanges();
        }

        public IEnumerable<CartProductViewModel> GetUserProduct(string id)
        {
            var user = FindUserById(id);

            return user.Cart.Products
                .Select(p => new CartProductViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

        private User FindUserById(string id)
        {
            return context.Set<User>()
                .Where(u => u.Id == id)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();
        }
    }
}
