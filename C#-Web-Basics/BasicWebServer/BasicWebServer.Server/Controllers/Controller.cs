﻿using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Controllers
{
    public class Controller
    {
        public Controller(Request request)
        {
            Request = request;
        }

        public Request Request { get; }
    }
}
