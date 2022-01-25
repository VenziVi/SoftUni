﻿using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable() =>
            routes = new ()
        {
                [Method.GET] = new (StringComparer.InvariantCultureIgnoreCase),
                [Method.PUT] = new (StringComparer.InvariantCultureIgnoreCase),
                [Method.POST] = new (StringComparer.InvariantCultureIgnoreCase),
                [Method.DELETE] = new (StringComparer.InvariantCultureIgnoreCase)
        };

        public IRoutingTable Map(string url, Method method, Response response)
            => method switch
            {
                Method.GET => this.MapGet(url, response),
                Method.POST => this.MapPost(url, response),
                _ => throw new InvalidOperationException($"{method} is not supported.")
        };

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.GET][url] = response;
            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.POST][url] = response;
            return this;
        }

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!routes.ContainsKey(requestMethod) ||
                !routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return routes[requestMethod][requestUrl];
        }
    }
}
