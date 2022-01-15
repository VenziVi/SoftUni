using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class NotFoundResponse : ContentResponse
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }
    }
}
