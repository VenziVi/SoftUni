namespace BasicWebServer.Server.HTTP
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string _text) 
            : base(_text, ContentType.Html)
        {
        }
    }
}
