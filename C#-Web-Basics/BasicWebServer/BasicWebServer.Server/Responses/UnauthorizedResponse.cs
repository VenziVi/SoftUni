using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class UnauthorizedResponse : ContentResponse
    {
        public UnauthorizedResponse() 
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
