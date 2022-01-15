namespace BasicWebServer.Server.HTTP
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string _text,
            Action<Request, Response> _preRenderAction = null) 
            : base(_text, ContentType.PlainText, _preRenderAction)
        {
        }
    }
}
