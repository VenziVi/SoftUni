namespace BasicWebServer.Server.HTTP
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string _text,
            Action<Request, Response> _preRenderAction = null) 
            : base(_text, ContentType.Html, _preRenderAction)
        {
        }
    }
}
