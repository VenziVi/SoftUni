using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.UserModels;
using System;
using System.Collections.Generic;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(Request request) 
            : base(request)
        {
        }

        public Response Add() => View();
        public Response Create() => View();
    }
}
