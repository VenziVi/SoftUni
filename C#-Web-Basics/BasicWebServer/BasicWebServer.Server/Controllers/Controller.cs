﻿using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Controllers
{
    public abstract class Controller
    {
        public Controller(Request request)
        {
            Request = request;
        }

        protected Request Request { get; private init; }

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string text) => new HtmlResponse(text);

        protected Response BadRequest() => new BadRequestResponse();

        protected Response Unauthorized() => new UnauthorizedResponse();

        protected Response NotFoind() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response File(string fileName) => new TextFileResponse(fileName);
    }
}
