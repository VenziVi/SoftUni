using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.ProductModels;
using SMS.Models.UserModels;
using System;
using System.Collections.Generic;

namespace SMS.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;

        public ProductsController(Request request,
            IProductService _productService,
            IUserService _userService) 
            : base(request)
        {
            productService = _productService;
            userService = _userService;
        }


        public Response Create() => View();

        [HttpPost]
        public Response Create(CreateViewModel model)
        {
            (bool isCreated, List<ErrorViewModel> Errors) = productService.CreateProduct(model);

            if (!isCreated)
            {
                return View(Errors, "/Error");
            }

            return Redirect("/Home/IndexLoggedin");
        }
    }
}
