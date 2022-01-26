using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(
            Method method,
            string path, 
            Func<Request, Response> ResponseFunction);

        IRoutingTable MapGet(
            string path,
            Func<Request, Response> ResponseFunction);

        IRoutingTable MapPost(
            string path,
            Func<Request, Response> ResponseFunction);
    }
}
