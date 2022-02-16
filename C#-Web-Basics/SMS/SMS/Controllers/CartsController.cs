using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.HomeModels;
using SMS.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartSevice;
        public CartsController(Request request,
            ICartService _cartSevice) 
            : base(request)
        {
            cartSevice = _cartSevice;
        }

        [Authorize]
        public Response Details()
        {
            IEnumerable<CartProductViewModel> products = cartSevice.GetUserProduct(User.Id);

            return View(new
            {
                Products = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            IEnumerable<CartProductViewModel> products = cartSevice.AddProductToCart(User.Id, productId);

            return View(new
            {
                Products = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            cartSevice.BuyProducts(User.Id);

            return Redirect("/");
        }
    }
}
