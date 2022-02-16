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

        public ProductsController(Request request,
            IProductService _productService)
            : base(request)
        {
            productService = _productService;
        }

        [Authorize]
        public Response Create() => View(new { IsAuthenticated = true });

        [Authorize]
        [HttpPost]
        public Response Create(CreateViewModel model)
        {
            (bool isCreated, List<ErrorViewModel> Errors) = productService.CreateProduct(model);

            if (!isCreated)
            {
                return View(Errors, "/Error");
            }

            return Redirect("/");
        }
    }
}
