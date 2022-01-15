using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponse : ContentResponse
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
