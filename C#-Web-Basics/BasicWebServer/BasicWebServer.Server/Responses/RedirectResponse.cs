using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class RedirectResponse : ContentResponse
    {
        public RedirectResponse(string _location) 
            : base(StatusCode.Found)
        {
            Headers.Add(Header.Location, _location);
        }
    }
}
